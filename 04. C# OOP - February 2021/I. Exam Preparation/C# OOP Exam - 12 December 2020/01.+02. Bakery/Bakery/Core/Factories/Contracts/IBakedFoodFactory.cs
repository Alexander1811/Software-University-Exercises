using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Core.Factories.Contracts
{
    public interface IBakedFoodFactory 
    {
        IBakedFood CreateFood(string type, string name, decimal price);
    }
}
