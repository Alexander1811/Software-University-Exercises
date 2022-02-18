namespace VaporStore.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Common;
    using Data.Models;
    using Data.Models.Enums;

    [XmlType(nameof(Purchase))]
    public class ImportPurchaseDto
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(typeof(PurchaseType), ValidationConstants.PurchaseTypeMinValue, ValidationConstants.PurchaseTypeMaxValue)]
        public string Type { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.PurchaseProductKeyRegex)]
        public string Key { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.CardNumberRegex)]
        public string Card { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
