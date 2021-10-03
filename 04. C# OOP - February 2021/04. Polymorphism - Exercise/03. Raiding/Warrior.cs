namespace _03._Raiding
{
    public class Warrior : BaseHero
    {
        private const int BasePower = 100;
        public Warrior(string name)
            : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
