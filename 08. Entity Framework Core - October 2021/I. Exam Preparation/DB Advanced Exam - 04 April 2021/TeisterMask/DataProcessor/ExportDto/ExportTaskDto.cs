namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    using Data.Models;

    [XmlType(nameof(Task))]
    public class ExportTaskDto
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; }

        [XmlElement(nameof(Label))]
        public string Label { get; set; }
    }
}
