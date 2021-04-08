using Bakery.Models.Drinks.Contracts;

namespace Bakery.Core.Factories.Contracts
{
    public interface IDrinkFactory
    {
        IDrink CreateDrink(string type, string name, int portion, string brand);
    }
}
