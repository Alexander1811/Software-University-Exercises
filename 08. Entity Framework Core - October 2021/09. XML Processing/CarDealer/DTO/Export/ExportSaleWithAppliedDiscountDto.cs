namespace CarDealer.DTO.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSaleWithAppliedDiscountDto
    {
        [XmlElement("car")]
        public ExportCarSaleDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
