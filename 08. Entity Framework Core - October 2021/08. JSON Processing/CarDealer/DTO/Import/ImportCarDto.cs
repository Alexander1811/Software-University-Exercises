namespace CarDealer.DTO.Import
{
    using System.Collections.Generic;

    public class ImportCarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int TravelledDistance { get; set; }

        public ICollection<int> PartsId = new List<int>();
    }
}
