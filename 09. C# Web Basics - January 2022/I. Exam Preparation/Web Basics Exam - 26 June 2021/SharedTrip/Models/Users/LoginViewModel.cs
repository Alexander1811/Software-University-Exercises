namespace SharedTrip.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using Constants = SharedTrip.Common.ValidationConstants;
    using Errors = SharedTrip.Common.ErrorMessages;

    public class LoginViewModel
    {
        [Required]
        [StringLength(Constants.UserUsernameMaxLength, 
            MinimumLength = Constants.UserUsernameMinLength, 
            ErrorMessage = Errors.UserInvalidUsername)]
        public string Username { get; set; }

        [Required]
        [StringLength(Constants.UserPasswordMaxLength,
            MinimumLength = Constants.UserPasswordMinLength,
            ErrorMessage = Errors.UserInvalidPassword)]
        public string Password { get; set; }
    }
}
