namespace Bakery.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.BakedFoods;
    using Models.BakedFoods.Contracts;

    public class BakedFoodFactory : IBakedFoodFactory
    {
        public IBakedFood CreateFood(string type, string name, decimal price)
        {
            //Type foodType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            //IBakedFood food = (IBakedFood)Activator.CreateInstance(foodType, name, price);

            IBakedFood food;

            switch (type)
            {
                case nameof(Bread):
                    food = new Bread(name, price);
                    break;
                case nameof(Cake):
                    food = new Cake(name, price);
                    break;
                default:
                    food = null;
                    break;
            }

            return food;
        }
    }
}
