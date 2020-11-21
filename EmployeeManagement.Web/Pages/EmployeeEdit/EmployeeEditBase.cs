using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.EmployeeEdit
{
    public class EmployeeEditBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        private Employee Employee { get; set; } = new Employee();

        public EmployeeEditModel EmployeeEditModelObject { get; set; } = new EmployeeEditModel();

        public List<Department> Departments = new List<Department>();

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();

            EmployeeEditModelObject.EmployeeId = Employee.EmployeeId;
            EmployeeEditModelObject.FirstName = Employee.FirstName;
            EmployeeEditModelObject.LastName = Employee.LastName;
            EmployeeEditModelObject.Email = Employee.Email;
            EmployeeEditModelObject.ConfirmEmail = Employee.Email;
            EmployeeEditModelObject.Gender = Employee.Gender;
            EmployeeEditModelObject.DepartmentId = Employee.DepartmentId;
            EmployeeEditModelObject.Department = Employee.Department;
            EmployeeEditModelObject.DateOfBirth = Employee.DateOfBirth;
            EmployeeEditModelObject.PhotoPath = Employee.PhotoPath;

        }

        public void HandleValidSubmission() { }
    }
}
