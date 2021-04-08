namespace Players_and_Monsters.Core.Factories.Contracts
{
    using Players_and_Monsters.Models.Players.Contracts;

    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string type, string username);
    }
}
