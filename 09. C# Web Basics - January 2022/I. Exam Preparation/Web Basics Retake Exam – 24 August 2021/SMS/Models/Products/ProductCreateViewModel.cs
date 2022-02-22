namespace SMS.Models.Products
{
    using System.ComponentModel.DataAnnotations;
    using Validations = SMS.Common.ValidationConstants;
    using Errors = SMS.Common.ErrorMessages;

    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = Errors.ProductRequiredName)]
        [StringLength(Validations.ProductNameMaxLength, 
            MinimumLength = Validations.ProductNameMinLength,
            ErrorMessage = Errors.ProductInvalidName)]
        public string Name { get; set; }

        public string Price { get; set; }
    }
}
