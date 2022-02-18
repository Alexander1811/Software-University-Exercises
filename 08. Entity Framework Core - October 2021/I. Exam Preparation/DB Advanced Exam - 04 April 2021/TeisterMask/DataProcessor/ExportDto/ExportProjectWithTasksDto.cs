namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    using Data.Models;

    [XmlType(nameof(Project))] 
    public class ExportProjectWithTasksDto
    {
        [XmlAttribute(nameof(TasksCount))]
        public int TasksCount { get; set; }

        [XmlElement(nameof(ProjectName))]
        public string ProjectName { get; set; }

        [XmlElement(nameof(HasEndDate))]
        public string HasEndDate { get; set; }

        [XmlArray(nameof(Tasks))]
        public ExportTaskDto[] Tasks { get; set; }
    }
}
