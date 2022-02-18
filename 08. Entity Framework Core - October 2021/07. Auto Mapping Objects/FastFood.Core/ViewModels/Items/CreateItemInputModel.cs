namespace FastFood.Core.ViewModels.Items
{
    using System.ComponentModel.DataAnnotations;

    public class CreateItemInputModel
    {
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
