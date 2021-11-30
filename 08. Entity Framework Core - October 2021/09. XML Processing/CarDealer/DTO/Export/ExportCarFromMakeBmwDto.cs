namespace CarDealer.DTO.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarFromMakeBmwDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
