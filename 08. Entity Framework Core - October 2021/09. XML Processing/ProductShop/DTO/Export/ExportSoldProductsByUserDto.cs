namespace ProductShop.DTO.Export
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(User))]
    public class ExportSoldProductsByUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ExportSoldProductDto[] ProductsSold { get; set; }
    }
}
