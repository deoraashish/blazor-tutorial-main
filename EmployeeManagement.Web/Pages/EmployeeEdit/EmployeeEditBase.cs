using AutoMapper;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.EmployeeEdit
{
    public class EmployeeEditBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        public string FormHeaderText { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        public IMapper Imapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected Employee Employee { get; set; } = new Employee();

        public EmployeeEditModel EmployeeEditModelObject { get; set; } = new EmployeeEditModel();

        public List<Department> Departments = new List<Department>();

        protected async override Task OnInitializedAsync()
        {
            Departments = (await DepartmentService.GetDepartments()).ToList();
            int.TryParse(Id, out int employeeid);

            if (employeeid == 0)
            {
                Employee = new Employee
                {
                    DepartmentId = 2,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"
                };

                FormHeaderText = "Add Employee";
            }
            else
            {
                FormHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            Imapper.Map(Employee, EmployeeEditModelObject);

            //EmployeeEditModelObject.EmployeeId = Employee.EmployeeId;
            //EmployeeEditModelObject.FirstName = Employee.FirstName;
            //EmployeeEditModelObject.LastName = Employee.LastName;
            //EmployeeEditModelObject.Email = Employee.Email;
            //EmployeeEditModelObject.ConfirmEmail = Employee.Email;
            //EmployeeEditModelObject.Gender = Employee.Gender;
            //EmployeeEditModelObject.DepartmentId = Employee.DepartmentId;
            //EmployeeEditModelObject.Department = Employee.Department;
            //EmployeeEditModelObject.DateOfBirth = Employee.DateOfBirth;
            //EmployeeEditModelObject.PhotoPath = Employee.PhotoPath;

        }

        public async Task HandleValidSubmit()
        {
            Imapper.Map(EmployeeEditModelObject, Employee);

            try
            {
                if (Employee.EmployeeId != 0)
                {
                    var result = await EmployeeService.UpdateEmployee(Employee);
                }
                else
                {
                    var result = await EmployeeService.AddEmployee(Employee);
                }

                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {

            }

        }

        public async Task onDeleteClick()
        {
            try
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
