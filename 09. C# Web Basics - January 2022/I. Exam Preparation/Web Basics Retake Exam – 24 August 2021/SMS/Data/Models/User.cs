namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Validations = SMS.Common.ValidationConstants;

    public class User
    {
        [Key]
        [StringLength(Validations.GuidLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Validations.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(Validations.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(Validations.UserDatabasePasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }
        public Cart Cart { get; set; } = new Cart();
    }
}
