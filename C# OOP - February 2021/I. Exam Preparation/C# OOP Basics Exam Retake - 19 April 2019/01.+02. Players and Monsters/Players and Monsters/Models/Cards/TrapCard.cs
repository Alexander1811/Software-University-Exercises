using Players_and_Monsters.Models.Cards.Contracts;

namespace Players_and_Monsters.Models.Cards
{
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
