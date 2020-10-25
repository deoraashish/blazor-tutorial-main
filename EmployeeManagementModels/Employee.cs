using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public string PhotoPath { get; set; }
    }
}
