namespace FastFood.Services.DTO.Order
{
    public class CreateOrderDto
    {
        public string Customer { get; set; }

        public decimal ItemPrice { get; set; }

        public int EmployeeId { get; set; }

        public int Quantity { get; set; }
    }
}
