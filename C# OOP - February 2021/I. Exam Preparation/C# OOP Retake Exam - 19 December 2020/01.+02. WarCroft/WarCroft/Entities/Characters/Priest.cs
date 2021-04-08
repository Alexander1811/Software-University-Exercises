using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double PriestBaseHealth = 50;
        private const double PriestBaseArmor = 25;
        private const double PriestAbilityPoints = 40;

        public Priest(string name)
            : base(name, PriestBaseHealth, PriestBaseArmor, PriestAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
            else if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
