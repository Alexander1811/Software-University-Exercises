namespace PlayersAndMonsters.Core.Factories.Contracts
{
    using Models.Players.Contracts;

    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string type, string username);
    }
}
