using EmployeeManagementModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> AddEmployee(Employee newEmployee);
        Task DeleteEmployee(int id);
    }
}
