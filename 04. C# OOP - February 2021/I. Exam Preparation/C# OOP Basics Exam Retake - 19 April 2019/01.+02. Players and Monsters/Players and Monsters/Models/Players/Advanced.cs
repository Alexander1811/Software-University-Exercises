namespace PlayersAndMonsters.Models.Players
{
    using Contracts;
    using Repositories.Contracts;

    public class Advanced : Player, IPlayer
    {
        private const int InitalHealth = 250;
        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, InitalHealth)
        {
        }
    }
}
