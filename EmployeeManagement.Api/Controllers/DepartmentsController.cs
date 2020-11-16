using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Departments()
        {
            try
            {
                var departments = await this.departmentRepository.GetDepartments();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to fetch departments from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Department(int id)
        {
            try
            {
                var department = await this.departmentRepository.GetDepartment(id);
                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to fetch department from DB");
            }
        }
    }
}
