using EmployeeManagement.Api.Models;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository iEmployeeRepository;

        public EmployeesController(IEmployeeRepository iEmployeeRepository)
        {
            this.iEmployeeRepository = iEmployeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                var employees = await this.iEmployeeRepository.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to fetch employees from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var employee = await this.iEmployeeRepository.GetEmployee(id);
                if (employee == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Employee Not Found");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to fetch employees from DB");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please provide correct data");
                }

                var emp = iEmployeeRepository.GetEmployeeByEmail(employee.Email);

                if (emp != null)
                {
                    ModelState.AddModelError("Error", "Email already taken");
                    return BadRequest(ModelState);
                }
                var result = await this.iEmployeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = result.EmployeeId }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to fetch employees from DB");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID Mismatch");
                }
                var emp = await iEmployeeRepository.GetEmployee(id);
                if (emp == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                return await iEmployeeRepository.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating data = {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var emp = await iEmployeeRepository.GetEmployee(id);
                if (emp == null)
                {
                    return NotFound($"Employee with {id} is not found");
                }

                return await iEmployeeRepository.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting data = {ex.Message}");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee(string name, Gender? gender)
        {
            try
            {
                var result = await iEmployeeRepository.SearchEmployee(name, gender);

                if(result.Any())
                {
                    return Ok(result);
                }
                else 
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
