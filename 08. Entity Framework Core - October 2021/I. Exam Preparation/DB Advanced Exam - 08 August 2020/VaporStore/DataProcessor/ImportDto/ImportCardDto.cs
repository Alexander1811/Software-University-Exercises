namespace VaporStore.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    
    using Common;
    using Data.Models.Enums;

    public class ImportCardDto
    {
        [Required]
        [RegularExpression(ValidationConstants.CardNumberRegex)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.CardCvcRegex)]
        [MaxLength(ValidationConstants.CardCvcMaxLength)]
        public string Cvc { get; set; }

        [Range(typeof(CardType), ValidationConstants.CardTypeMinValue, ValidationConstants.CardTypeMaxValue)]
        public string Type { get; set; }
    }
}
