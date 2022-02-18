namespace Theatre.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Theatre
    {
        public Theatre()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TheatreNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.TheatreNameMaxHallsCount)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TheatreDirectorNameMaxLength)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
