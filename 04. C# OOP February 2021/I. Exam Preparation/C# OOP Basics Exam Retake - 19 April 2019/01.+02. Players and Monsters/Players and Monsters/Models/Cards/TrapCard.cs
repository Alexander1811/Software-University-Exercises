namespace PlayersAndMonsters.Models.Cards
{
    using Contracts;

    public class TrapCard : Card, ICard
    {
        private const int InitalDamagePoints = 120;
        private const int InitalHealthPoints = 5;

        public TrapCard(string name)
            : base(name, InitalDamagePoints, InitalHealthPoints)
        {
        }
    }
}
