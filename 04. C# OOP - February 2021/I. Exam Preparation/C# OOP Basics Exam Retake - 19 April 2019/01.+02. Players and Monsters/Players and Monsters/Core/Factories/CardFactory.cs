using Players_and_Monsters.Core.Factories.Contracts;
using Players_and_Monsters.Models.Cards;
using Players_and_Monsters.Models.Cards.Contracts;

namespace Players_and_Monsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            if (type == "Magic")
            {
                card = new MagicCard(name);
            }
            else if (type == "Trap")
            {
                card = new TrapCard(name);
            }

            return card;
        }
    }
}
