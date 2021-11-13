namespace PlayersAndMonsters.Models.Cards
{
    using Common;
    using Contracts;

    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidCardName);

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidCardDamagePoints);

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidCardHealthPoints);

                this.healthPoints = value;
            }
        }
    }
}
