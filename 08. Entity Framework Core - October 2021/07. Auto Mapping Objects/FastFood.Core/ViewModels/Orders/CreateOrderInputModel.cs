namespace FastFood.Core.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderInputModel
    {
        [Required]
        public string Customer { get; set; }

        public int ItemId { get; set; }

        public decimal ItemPrice { get; set; }

        public int EmployeeId { get; set; }

        public int Quantity { get; set; }
    }
}
