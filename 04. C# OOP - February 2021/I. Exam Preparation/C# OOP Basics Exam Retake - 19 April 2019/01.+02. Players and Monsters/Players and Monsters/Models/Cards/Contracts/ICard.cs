namespace Players_and_Monsters.Models.Cards.Contracts
{
    public interface ICard
    {
        string Name { get; }

        int DamagePoints { get; set; }

        int HealthPoints { get; }
    }
}
