using EmployeeManagementModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<Department>> GetDepartments();
        public Task<Department> GetDepartment(int id);
    }
}
