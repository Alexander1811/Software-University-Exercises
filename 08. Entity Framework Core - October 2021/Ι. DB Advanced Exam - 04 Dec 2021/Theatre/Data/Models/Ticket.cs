namespace Theatre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.TicketPriceMinValue, ValidationConstants.TicketPriceMaxValue)]
        public decimal Price { get; set; }

        [Range(ValidationConstants.TicketRowMinCount, ValidationConstants.TicketRowMaxCount)]
        public sbyte RowNumber { get; set; }

        [ForeignKey(nameof(Models.Play))]
        public int PlayId { get; set; }
        public virtual Play Play { get; set; }

        [ForeignKey(nameof(Models.Theatre))]
        public int TheatreId { get; set; }
        public virtual Theatre Theatre { get; set; }
    }
}