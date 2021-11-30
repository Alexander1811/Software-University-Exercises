namespace CarDealer.DTO.Import
{
    using System.Xml.Serialization;
    
    using Models;

    [XmlType(nameof(Customer))]
    public class ImportCustomerDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public string BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public string IsYoungDriver { get; set; }
    }
}
