namespace VaporStore.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    
    using Common;

    public class ImportUserDto
    {
        [Required]
        [RegularExpression(ValidationConstants.UserFullNameRegex)]
        public string FullName { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserUsernameMinLength)]
        [MaxLength(ValidationConstants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(ValidationConstants.UserAgeMinValue, ValidationConstants.UserAgeMaxValue)]
        public int Age { get; set; }

        [MinLength(ValidationConstants.UserCardsMinCount)]
        public ImportCardDto[] Cards { get; set; }
    }
}
