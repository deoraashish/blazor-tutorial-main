using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;

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

        public async void OnSelectionChanged(ChangeEventArgs e)
        {
            await this.EmployeeSelected.InvokeAsync((bool)e.Value);
        }
    }
}
