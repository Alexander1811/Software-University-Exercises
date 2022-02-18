namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Data.Models;
    using Theatre.Common;

    [XmlType(nameof(Cast))]
    public class ImportCastDto
    {
        [XmlElement(nameof(Cast.FullName))]
        [Required]
        [MinLength(ValidationConstants.CastFullNameMinLength)]
        [MaxLength(ValidationConstants.CastFullNameMaxLength)]
        public string FullName { get; set; }

        [XmlElement(nameof(Cast.IsMainCharacter))]
        public string IsMainCharacter { get; set; }

        [XmlElement(nameof(Cast.PhoneNumber))]
        [RegularExpression(ValidationConstants.CastPhoneNumberRegex)]
        public string PhoneNumber { get; set; }

        [XmlElement(nameof(Cast.PlayId))]
        public int PlayId { get; set; }
    }
}
