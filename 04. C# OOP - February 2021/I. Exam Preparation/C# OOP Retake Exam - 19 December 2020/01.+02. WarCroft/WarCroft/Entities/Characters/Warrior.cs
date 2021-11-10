namespace WarCroft.Entities.Characters
{
    using System;

    using Constants;
    using Contracts;
    using Inventory;

    public class Warrior : Character, IAttacker
    {
        private const double WarriorBaseHealth = 100;
        private const double WarriorBaseArmor = 50;
        private const double WarriorAbilityPoints = 40;

        public Warrior(string name)
            : base(name, WarriorBaseHealth, WarriorBaseArmor, WarriorAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this == character)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            if (this.IsAlive && character.IsAlive)
            {
                character.TakeDamage(this.AbilityPoints);
            }
            else if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
