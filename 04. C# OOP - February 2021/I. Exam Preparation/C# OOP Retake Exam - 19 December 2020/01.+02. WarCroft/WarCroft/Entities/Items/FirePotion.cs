namespace WarCroft.Entities.Items
{
    using Characters.Contracts;

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
