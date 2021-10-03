using Players_and_Monsters.Models.Players.Contracts;
using Players_and_Monsters.Repositories.Contracts;

namespace Players_and_Monsters.Models.Players
{
    public class Advanced : Player, IPlayer
    {
        private const int InitalHealth = 250;
        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, InitalHealth)
        {
        }
    }
}
