namespace Bakery.Core.Factories.Contracts
{
    using Models.Drinks.Contracts;

    public interface IDrinkFactory
    {
        IDrink CreateDrink(string type, string name, int portion, string brand);
    }
}
