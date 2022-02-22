namespace SMS.Contracts
{
    public interface IValidationService
    {
        (bool isValid, string errors) ValidateModel(object model);
    }
}
