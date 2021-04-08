using Players_and_Monsters.Models.Players.Contracts;
using Players_and_Monsters.Repositories.Contracts;

namespace Players_and_Monsters.Models.Players
{
    public class Beginner : Player, IPlayer
    {
        private const int InitalHealth = 50;

        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, InitalHealth)
        {
        }
    }
}
