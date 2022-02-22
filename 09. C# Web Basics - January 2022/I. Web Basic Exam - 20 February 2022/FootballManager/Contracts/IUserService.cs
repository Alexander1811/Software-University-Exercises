namespace FootballManager.Contracts
{
    using FootballManager.ViewModels.Users;

    public interface IUserService
    {
        bool ValidateModel(RegisterViewModel model);

        void RegisterUser(RegisterViewModel model);

        (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model);
    }
}