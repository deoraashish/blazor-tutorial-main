using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages.DataBindingExample
{
    public class DataBindingDemoBase : ComponentBase
    {
        protected string Name { get; set; } = "Tom";

        public string Gender { get; set; } = "Male";

        public string color { get; set; } = "background-color: red";
    }
}
