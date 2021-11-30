namespace ProductShop.DTO.Export
{
    using System.Xml.Serialization;

    [XmlType(null)]
    public class ExportUsersWithProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserWithProductsDto[] Users { get; set; }
    }
}
