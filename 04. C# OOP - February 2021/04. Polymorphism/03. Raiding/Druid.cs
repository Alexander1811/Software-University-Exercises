namespace P03_Raiding
{
    public class Druid : BaseHero
    {
        private const int BasePower = 80;
        public Druid(string name) 
            : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
