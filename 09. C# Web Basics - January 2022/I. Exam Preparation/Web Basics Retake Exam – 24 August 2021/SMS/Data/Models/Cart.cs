namespace SMS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Validations = SMS.Common.ValidationConstants;

    public class Cart
    {
        [Key]
        [StringLength(Validations.GuidLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
