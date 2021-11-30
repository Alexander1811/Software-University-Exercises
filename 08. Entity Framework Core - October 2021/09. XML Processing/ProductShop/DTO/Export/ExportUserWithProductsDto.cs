namespace ProductShop.DTO.Export
{
    using System.Xml.Serialization;
    
    using Models;

    [XmlType(nameof(User))]
    public class ExportUserWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportProductsByUserDto SoldProducts { get; set; }
    }
}
