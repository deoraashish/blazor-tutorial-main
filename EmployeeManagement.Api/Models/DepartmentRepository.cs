using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext appDBContext;

        public DepartmentRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            var result = await appDBContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDBContext.Departments.ToListAsync();
        }
    }
}
