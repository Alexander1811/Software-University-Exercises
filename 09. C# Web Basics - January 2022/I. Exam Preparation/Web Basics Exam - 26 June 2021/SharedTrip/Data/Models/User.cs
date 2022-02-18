namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants = SharedTrip.Common.ValidationConstants;

    public class User
    {
        public User()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [StringLength(Constants.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(Constants.UserDatabasePasswordMaxLength)]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
