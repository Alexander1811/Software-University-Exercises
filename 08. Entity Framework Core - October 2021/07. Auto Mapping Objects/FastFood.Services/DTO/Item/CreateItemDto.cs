namespace FastFood.Services.DTO.Item
{
    public class CreateItemDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
