using System.Collections.Generic;
using _04._Wild_Farm.Foods;

namespace _04._Wild_Farm.Animals.Mammals
{
    public class Tiger : Feline
    {
        private const double WeightModifier = 1.00;
        private static HashSet<string> tigerAllowedFoods = new HashSet<string>() { nameof(Meat) };

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, tigerAllowedFoods, WeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
