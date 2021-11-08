namespace P03Raiding
{
    public class Paladin : BaseHero
    {
        private const int BasePower = 100;
        public Paladin(string name)
            : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
