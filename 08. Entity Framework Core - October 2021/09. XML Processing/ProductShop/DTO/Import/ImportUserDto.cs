namespace ProductShop.DTO.Import
{
    using System.Xml.Serialization;
    
    using Models;

    [XmlType(nameof(User))]
    public class ImportUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }
    }
}
