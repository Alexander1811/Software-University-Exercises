namespace Theatre.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;

    using Data.Models;
    using Data.Models.Enums;

    [XmlType("Actor")]
    public class ExportActorDto
    {
        [XmlAttribute(nameof(Cast.FullName))]
        public string FullName { get; set; }

        [XmlAttribute("MainCharacter")]
        public string MainCharacter { get; set; }
    }
}
