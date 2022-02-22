namespace FootballManager.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using Validations = FootballManager.Common.ValidationConstants;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(Validations.UserUsernameMaxLength, MinimumLength = Validations.UserUsernameMinLength)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(Validations.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(Validations.UserPasswordMaxLength, MinimumLength = Validations.UserPasswordMinLength)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
