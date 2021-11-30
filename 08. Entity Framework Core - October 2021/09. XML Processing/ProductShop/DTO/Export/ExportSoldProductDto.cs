namespace ProductShop.DTO.Export
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(Product))]
    public class ExportSoldProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
