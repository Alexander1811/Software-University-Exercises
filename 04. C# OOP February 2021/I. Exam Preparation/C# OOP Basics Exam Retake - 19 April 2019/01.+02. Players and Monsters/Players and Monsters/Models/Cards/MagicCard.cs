
namespace PlayersAndMonsters.Models.Cards
{
    using Contracts;

    public class MagicCard : Card, ICard
    {
        private const int InitalDamagePoints = 5;
        private const int InitalHealthPoints = 80;

        public MagicCard(string name)
            : base(name, InitalDamagePoints, InitalHealthPoints)
        {
        }
    }
}
