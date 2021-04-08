using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int PotionWeight = 5;
        private const double PotionStrength = 20;

        public FirePotion()
            : base(PotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= PotionStrength;
        }
    }
}
