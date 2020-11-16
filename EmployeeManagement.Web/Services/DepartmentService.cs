using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        public HttpClient httpClient { get; set; }

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await this.httpClient.GetJsonAsync<Department>($"api/department/{id}");
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await this.httpClient.GetJsonAsync<IEnumerable<Department>>($"api/departments");
        }
    }
}
