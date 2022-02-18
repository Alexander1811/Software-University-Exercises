namespace TeisterMask.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;
    using Enums;

    public class Task
    {
        public Task()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TaskNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public ExecutionType ExecutionType { get; set; }

        public LabelType LabelType { get; set; }

        [ForeignKey(nameof(Models.Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}