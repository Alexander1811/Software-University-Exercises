namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    
    using Common;
    using Data.Models;

    [XmlType(nameof(Task))]
    public class ImportTaskDto
    {
        [XmlElement(nameof(Task.Name))]
        [MinLength(ValidationConstants.TaskNameMinLength)]
        [MaxLength(ValidationConstants.TaskNameMaxLength)]
        public string Name { get; set; }

        [XmlElement(nameof(Task.OpenDate))]
        public string OpenDate { get; set; }

        [XmlElement(nameof(Task.DueDate))]
        public string DueDate { get; set; }

        [XmlElement(nameof(Task.ExecutionType))]
        [Range(ValidationConstants.TaskExecutionTypeMinValue, ValidationConstants.TaskExecutionTypeMaxValue)]
        public int ExecutionType { get; set; }

        [XmlElement(nameof(Task.LabelType))]
        [Range(ValidationConstants.TaskLabelTypeMinValue, ValidationConstants.TaskLabelTypeMaxValue)]
        public int LabelType { get; set; }
    }
}
