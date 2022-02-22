namespace SMS.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using Validations = SMS.Common.ValidationConstants;
    using Errors = SMS.Common.ErrorMessages;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = Errors.UserRequiredUsername)]
        [StringLength(Validations.UserUsernameMaxLength, 
            MinimumLength = Validations.UserUsernameMinLength, 
            ErrorMessage = Errors.UserInvalidUsername)]
        public string Username { get; set; }

        [Required(ErrorMessage = Errors.UserRequiredEmail)]
        [EmailAddress(ErrorMessage = Errors.UserInvalidEmail)]
        [StringLength(Validations.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required(ErrorMessage = Errors.UserRequiredPassword)]
        [StringLength(Validations.UserPasswordMaxLength, 
            MinimumLength = Validations.UserPasswordMinLength, 
            ErrorMessage = Errors.UserInvalidPassword)]
        public string Password { get; set; }

        [Required(ErrorMessage =Errors.UserRequiredConfirmPassword)]
        [Compare(nameof(Password), ErrorMessage = Errors.UserInvalidConfirmPassword)]
        public string ConfirmPassword { get; set; }
    }
}
