using System;
using System.Linq;
using System.Reflection;
using Bakery.Core.Factories.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;

namespace Bakery.Core.Factories
{
    public class DrinkFactory : IDrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int portion, string brand)
        {
            //Type drinkType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            //IDrink drink = (IDrink)Activator.CreateInstance(drinkType, name, portion, brand);

            IDrink drink;

            switch (type)
            {
                case nameof(Tea):
                    drink = new Tea(name, portion, brand);
                    break;
                case nameof(Water):
                    drink = new Water(name, portion, brand);
                    break;
                default:
                    drink = null;
                    break;
            }

            return drink;
        }
    }
}
