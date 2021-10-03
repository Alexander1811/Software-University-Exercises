namespace Players_and_Monsters.Core.Factories.Contracts
{
    using Players_and_Monsters.Models.Cards.Contracts;

    public interface ICardFactory
    {
        ICard CreateCard(string type, string name);
    }
}
