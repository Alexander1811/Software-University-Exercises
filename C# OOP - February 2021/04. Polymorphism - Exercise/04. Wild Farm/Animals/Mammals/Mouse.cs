using System.Collections.Generic;
using _04._Wild_Farm.Foods;

namespace _04._Wild_Farm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WeightModifier = 0.10;
        private static HashSet<string> mouseAllowedFoods = new HashSet<string>() { nameof(Vegetable), nameof(Fruit) };

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, mouseAllowedFoods, WeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
