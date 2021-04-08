using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.BaseHealth = this.Health;
            this.Armor = armor;
            this.BaseArmor = this.Armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value >= 0 || value <= this.BaseHealth)
                {
                    this.health = value;
                }
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                    this.Health = 0;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value >= 0)
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (hitPoints > this.Armor)
            {
                this.Health -= hitPoints - this.Armor;
                this.Armor = 0;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                    this.Health = 0;
                }
            }
            else if (hitPoints <= this.Armor)
            {
                this.Armor -= hitPoints;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}