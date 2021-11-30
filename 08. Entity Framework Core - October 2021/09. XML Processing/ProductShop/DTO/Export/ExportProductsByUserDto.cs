namespace ProductShop.DTO.Export
{
    using System.Xml.Serialization;

    public class ExportProductsByUserDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportSoldProductDto[] Products { get; set; }
    }
}
