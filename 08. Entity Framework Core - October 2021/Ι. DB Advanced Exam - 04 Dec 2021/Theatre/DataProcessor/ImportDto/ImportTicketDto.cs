namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ImportTicketDto
    {
        [Range(ValidationConstants.TicketPriceMinValue, ValidationConstants.TicketPriceMaxValue)]
        public decimal Price { get; set; }

        [Range(ValidationConstants.TicketRowMinCount, ValidationConstants.TicketRowMaxCount)]
        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }
    }
}