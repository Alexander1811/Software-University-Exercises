namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Validations = SMS.Common.ValidationConstants;

    public class Product
    {
        [Key]
        [StringLength(Validations.GuidLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Validations.ProductNameMaxLength)]
        public string Name { get; set; }

        [Range(Validations.ProductPriceMinValue, Validations.ProductPriceMaxValue)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
