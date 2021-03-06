﻿using EmployeeManagementModels.CustomValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name cannot be empty")]
        [MinLength(2, ErrorMessage = "First name should be at least 2 char long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [EmailDomainValidation(ErrorMessage = "Please enter gptw.com addresses only", AllowedDomain = "gptw.com")]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
