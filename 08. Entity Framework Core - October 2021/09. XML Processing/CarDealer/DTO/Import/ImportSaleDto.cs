namespace CarDealer.DTO.Import
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(Sale))]
    public class ImportSaleDto
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }
    }
}
