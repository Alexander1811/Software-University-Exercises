namespace CarDealer.DTO.Import
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(Car))]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ImportPartCarDto[] Parts { get; set; }
    }
}
