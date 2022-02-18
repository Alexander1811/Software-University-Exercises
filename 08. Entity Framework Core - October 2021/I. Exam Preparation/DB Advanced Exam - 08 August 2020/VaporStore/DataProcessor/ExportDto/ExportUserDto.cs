namespace VaporStore.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    using Data.Models;

    [XmlType(nameof(User))]
    public class ExportUserDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public ExportPurchaseDto[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}
