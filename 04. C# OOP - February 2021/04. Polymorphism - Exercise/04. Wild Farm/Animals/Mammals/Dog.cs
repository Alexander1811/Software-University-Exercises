using System.Collections.Generic;
using _04._Wild_Farm.Foods;

namespace _04._Wild_Farm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double WeightModifier = 0.40;
        private static HashSet<string> dogAllowedFoods = new HashSet<string>() { nameof(Meat) };

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, dogAllowedFoods, WeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
