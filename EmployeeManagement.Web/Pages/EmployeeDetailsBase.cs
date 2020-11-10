using EmployeeManagement.Web.Services;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected string Coordinates { get; set; }

        protected bool showFooter { get; set; }

        protected string ButtonText { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Employee Employee { get; set; } = new Employee();

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            showFooter = false;
            ButtonText = "Show Footer";
        }

        protected void onMouseMove (MouseEventArgs e) 
        {
            Coordinates = $"X - {e.ClientX}, Y - {e.ClientY}";
        }

        protected void ToggleFooter(MouseEventArgs e)
        {
            showFooter = !showFooter;
            if (showFooter)
            {
                ButtonText = "Hide Footer";
            } 
            else
            {
                ButtonText = "Show Footer";
            }
        }

    }
}
