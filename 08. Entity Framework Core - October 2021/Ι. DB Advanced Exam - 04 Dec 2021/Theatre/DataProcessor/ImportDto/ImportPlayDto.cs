namespace Theatre.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    
    using Data.Models;
    using Data.Models.Enums;
    using Theatre.Common;

    [XmlType(nameof(Play))]
    public class ImportPlayDto
    {
        [XmlElement(nameof(Play.Title))]
        [Required]
        [MinLength(ValidationConstants.PlayTitleMinLength)]
        [MaxLength(ValidationConstants.PlayTitleMaxLength)]
        public string Title { get; set; }

        [XmlElement(nameof(Play.Duration))]
        public string Duration { get; set; }

        [XmlElement(nameof(Play.Rating))]
        [Range(ValidationConstants.PlayRatingMinValue, ValidationConstants.PlayRatingMaxValue)]
        public float Rating { get; set; }

        [XmlElement(nameof(Play.Genre))]
        [Range(typeof(Genre), ValidationConstants.PlayGenreMinValue, ValidationConstants.PlayGenreMaxValue)]
        public string Genre { get; set; }

        [XmlElement(nameof(Play.Description))]
        [Required]
        [MaxLength(ValidationConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; }

        [XmlElement(nameof(Play.Screenwriter))]
        [MinLength(ValidationConstants.PlayScreenwriterNameMinLength)]
        [MaxLength(ValidationConstants.PlayScreenwriterNameMaxLength)]
        public string Screenwriter { get; set; }
    }
}
