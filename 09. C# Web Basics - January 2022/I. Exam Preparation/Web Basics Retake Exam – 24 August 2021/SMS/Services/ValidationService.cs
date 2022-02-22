namespace SMS.Services
{
    using SMS.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ValidationService : IValidationService
    {
        public (bool isValid, string errors) ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, "");
            }

            string errors = string.Join(Environment.NewLine, errorResult.Select(e => e.ErrorMessage));

            return (isValid, errors);
        }
    }
}
