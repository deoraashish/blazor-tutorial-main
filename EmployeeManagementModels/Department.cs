using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementModels
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
