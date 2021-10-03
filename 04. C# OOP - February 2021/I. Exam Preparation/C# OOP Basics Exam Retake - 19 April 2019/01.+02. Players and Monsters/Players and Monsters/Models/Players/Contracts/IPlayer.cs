namespace Players_and_Monsters.Models.Players.Contracts
{
    using Players_and_Monsters.Repositories.Contracts;

    public interface IPlayer
    {
        ICardRepository CardRepository { get; }

        string Username { get; }

        int Health { get; set; }

        bool IsDead { get; }

        void TakeDamage(int damagePoints);
    }
}
