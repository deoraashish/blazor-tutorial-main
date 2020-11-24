using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> AddEmployee(Employee newEmployee)
        {
            return await httpClient.PostJsonAsync<Employee>("api/employees", newEmployee);
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            return await httpClient.PutJsonAsync<Employee>("api/employees", employee);
        }
    }
}
