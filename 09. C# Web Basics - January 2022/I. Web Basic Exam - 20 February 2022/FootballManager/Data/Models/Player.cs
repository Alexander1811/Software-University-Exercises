namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Validations = FootballManager.Common.ValidationConstants;

    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Validations.PlayerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(Validations.PlayerPositionMaxLength)]
        public string Position { get; set; }

        public byte Speed { get; set; }

        public byte Endurance { get; set; }

        [Required]
        [StringLength(Validations.PlayerDescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();
    }
}
