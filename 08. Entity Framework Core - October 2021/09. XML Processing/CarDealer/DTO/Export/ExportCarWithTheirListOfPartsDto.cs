namespace CarDealer.DTO.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarWithTheirListOfPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportPartCarDto[] Parts { get; set; }
    }
}
