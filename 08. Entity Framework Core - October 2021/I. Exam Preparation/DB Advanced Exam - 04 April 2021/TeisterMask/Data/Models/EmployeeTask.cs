namespace TeisterMask.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeTask
    {
        [ForeignKey(nameof(Models.Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(Models.Task))]
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
