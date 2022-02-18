namespace SharedTrip.Contracts
{
    using SharedTrip.Models;
    using SharedTrip.Models.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        public (bool isValid, List<ErrorViewModel> errors) ValidateModel(RegisterViewModel model);

        void RegisterUser(RegisterViewModel model);

        (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model);
    }
}