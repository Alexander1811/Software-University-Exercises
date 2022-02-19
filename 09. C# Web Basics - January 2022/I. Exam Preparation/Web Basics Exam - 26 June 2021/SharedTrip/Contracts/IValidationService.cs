namespace SharedTrip.Contracts
{
    using SharedTrip.Models;
    using System.Collections.Generic;

    public interface IValidationService
    {
        (bool isValid, List<ErrorViewModel> errors) ValidateModel(object model);
    }
}
