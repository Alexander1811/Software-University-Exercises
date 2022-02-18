namespace PlayersAndMonsters.Models.Players
{
    using Contracts;
    using Repositories.Contracts;

    public class Beginner : Player, IPlayer
    {
        private const int InitalHealth = 50;

        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, InitalHealth)
        {
        }
    }
}
