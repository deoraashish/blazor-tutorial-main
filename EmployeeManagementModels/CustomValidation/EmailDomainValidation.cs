using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementModels.CustomValidation
{
    public class EmailDomainValidation : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] emailAddressArray = value.ToString().Split('@');

            if (emailAddressArray[1].ToUpper() == AllowedDomain.ToUpper())
            {
                return null;
            }

            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
        }
    }
}
