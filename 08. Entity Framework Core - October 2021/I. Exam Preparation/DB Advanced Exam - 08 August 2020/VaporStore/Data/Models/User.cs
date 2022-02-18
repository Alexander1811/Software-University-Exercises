namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class User
    {
        public User()
        {
            this.Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(ValidationConstants.UserAgeMinValue, ValidationConstants.UserAgeMaxValue)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

    }
}
