namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    
    using Common;

    public class ImportTheatreDto
    {
        [Required]
        [MinLength(ValidationConstants.TheatreNameMinLength)]
        [MaxLength(ValidationConstants.TheatreNameMaxLength)]
        public string Name { get; set; }

        [Range(ValidationConstants.TheatreNameMinHallsCount, ValidationConstants.TheatreNameMaxHallsCount)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(ValidationConstants.TheatreDirectorNameMinLength)]
        [MaxLength(ValidationConstants.TheatreDirectorNameMaxLength)]
        public string Director { get; set; }

        public ImportTicketDto[] Tickets { get; set; }
    }
}
