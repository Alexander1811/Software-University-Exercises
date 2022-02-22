namespace FootballManager.Services
{
    using FootballManager.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class ValidationService : IValidationService
    {
        public bool ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errors = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errors, true);

            Console.WriteLine(string.Join(Environment.NewLine, errors));

            return isValid;
        }
    }
}
