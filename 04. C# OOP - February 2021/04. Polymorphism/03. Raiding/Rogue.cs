namespace P03_Raiding
{
    public class Rogue : BaseHero
    {
        private const int BasePower = 80;
        public Rogue(string name)
            : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
