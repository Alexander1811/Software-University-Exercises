namespace CarDealer.DTO.Import
{
    using System;

    public class ImportCustomerDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
