namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    
    using Common;
    using Data.Models;

    [XmlType(nameof(Project))]
    public class ImportProjectDto
    {
        [XmlElement(nameof(Project.Name))]
        [MinLength(ValidationConstants.ProjectNameMinLength)]
        [MaxLength(ValidationConstants.ProjectNameMaxLength)]
        public string Name { get; set; }

        [XmlElement(nameof(Project.OpenDate))]
        public string OpenDate { get; set; }

        [XmlElement(nameof(Project.DueDate))]
        public string DueDate { get; set; }

        [XmlArray(nameof(Project.Tasks))]
        public ImportTaskDto[] Tasks { get; set; }
    }
}
