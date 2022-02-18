namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(70)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required]
        [MaxLength(70)]
        public string Email { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
