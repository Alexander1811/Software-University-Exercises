namespace WarCroft.Entities.Items
{
    using Characters.Contracts;

    public class HealthPotion : Item
    {
        private const int PotionWeight = 5;
        private const int PotionStrength = 20;

        public HealthPotion()
            : base(PotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += PotionStrength;
        }
    }
}
