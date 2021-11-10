namespace PlayersAndMonsters.Models.Players
{
    using Common;
    using Contracts;
    using Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => this.username;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidPlayerName);

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InalidPlayerHealth);

                this.health = value;
            }
        }

        public bool IsDead => this.Health == 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsBelowZero(damagePoints, ExceptionMessages.InvalidDamagePoints);

            this.health -= damagePoints;

            if (this.health < 0)
            {
                this.health = 0;
            }
        }
    }
}
