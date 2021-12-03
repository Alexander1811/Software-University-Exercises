namespace VaporStore.DataProcessor.ExportDto
{
    using System.Xml.Serialization;
    
    using Data.Models;

    [XmlType(nameof(Game))]
    public class ExportGameDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement(nameof(Game.Genre))]
        public string Genre { get; set; }

        [XmlElement(nameof(Game.Price))]
        public decimal Price { get; set; }
    }
}
