namespace FastFood.Services.DTO.Order
{
    using System;

    public class ListAllOrdersDto
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public string Employee { get; set; }

        public string DateTime { get; set; }
    }
}
