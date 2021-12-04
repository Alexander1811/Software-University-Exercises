namespace Theatre.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;
    
    using Data.Models;
    using Data.Models.Enums;

    [XmlType(nameof(Play))]
    public class ExportPlayDto
    {
        [XmlAttribute(nameof(Play.Title))]
        public string Title { get; set; }

        [XmlAttribute(nameof(Play.Duration))]
        public string Duration { get; set; }

        [XmlAttribute(nameof(Play.Rating))]
        public string Rating { get; set; }

        [XmlAttribute(nameof(Play.Genre))]
        public string Genre { get; set; }

        [XmlArray("Actors")]
        public ExportActorDto[] Actors { get; set; }
    }
}
