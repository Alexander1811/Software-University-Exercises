namespace CarDealer.DTO.Import
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class ImportPartCarDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
