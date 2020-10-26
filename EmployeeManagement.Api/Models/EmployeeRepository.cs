using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext appDBContext;

        public EmployeeRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDBContext.Employees.AddAsync(employee);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await appDBContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                appDBContext.Employees.Remove(result);
                await appDBContext.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await appDBContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                return result;
            } else
            {
                return null;
            }
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            var result = await appDBContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDBContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchEmployee(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDBContext.Employees;

            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if(gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDBContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Gender = employee.Gender;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDBContext.SaveChangesAsync();

                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
