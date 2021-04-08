using System;
using System.Linq;
using System.Reflection;
using Bakery.Core.Factories.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Core.Factories
{
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
