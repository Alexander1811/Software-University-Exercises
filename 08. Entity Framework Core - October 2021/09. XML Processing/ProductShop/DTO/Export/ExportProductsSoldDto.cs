namespace ProductShop.DTO.Export
{
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExportProductsSoldDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportSoldProductDto[] Products { get; set; }
    }
}
