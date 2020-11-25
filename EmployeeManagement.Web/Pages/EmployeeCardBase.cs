using EmployeeManagement.Web.Services;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeCardBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> EmployeeSelected { get; set; }

        [Parameter]
        public EventCallback<int> DeletetionOfEmployeeEvent { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public async void OnSelectionChanged(ChangeEventArgs e)
        {
            await this.EmployeeSelected.InvokeAsync((bool)e.Value);
        }

        public async void DeleteButtonClickHandler(MouseEventArgs e)
        {
            await this.EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await this.DeletetionOfEmployeeEvent.InvokeAsync(Employee.EmployeeId);
        }
    }
}
