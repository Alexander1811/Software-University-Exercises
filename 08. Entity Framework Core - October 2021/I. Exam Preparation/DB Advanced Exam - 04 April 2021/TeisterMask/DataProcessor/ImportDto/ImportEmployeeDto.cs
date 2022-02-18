namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using TeisterMask.Common;

    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(ValidationConstants.EmployeeUsernameMinLength)]
        [MaxLength(ValidationConstants.EmployeeUsernameMaxLength)]
        [RegularExpression(ValidationConstants.EmployeeUsernameRegex)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.EmployeePhoneRegex)]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
