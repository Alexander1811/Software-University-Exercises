namespace SMS.Contracts
{
    using SMS.Models.Users;

    public interface IUserService
    {
        (bool isValid, string errors) ValidateModel(RegisterViewModel model);

        void RegisterUser(RegisterViewModel model);

        (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model);
        string GetUsername(string id);
    }
}