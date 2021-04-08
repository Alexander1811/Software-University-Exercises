using Players_and_Monsters.Models.Cards.Contracts;

namespace Players_and_Monsters.Models.Cards
{
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
