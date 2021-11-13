namespace Bakery.Core.Factories.Contracts
{
    using Models.BakedFoods.Contracts;

    public interface IBakedFoodFactory
    {
        IBakedFood CreateFood(string type, string name, decimal price);
    }
}
