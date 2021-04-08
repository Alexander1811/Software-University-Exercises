using Players_and_Monsters.Core.Factories.Contracts;
using Players_and_Monsters.Models.Players;
using Players_and_Monsters.Models.Players.Contracts;
using Players_and_Monsters.Repositories;

namespace Players_and_Monsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            if (type == nameof(Beginner))
            {
                player = new Beginner(new CardRepository(), username);
            }
            else if (type == nameof(Advanced))
            {
                player = new Advanced(new CardRepository(), username);
            }

            return player;
        }
    }
}
