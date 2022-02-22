namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Validations = FootballManager.Common.ValidationConstants;

    public class User
    {
        [Key]
        [StringLength(Validations.GuidLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Validations.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [StringLength(Validations.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();
    }
}
