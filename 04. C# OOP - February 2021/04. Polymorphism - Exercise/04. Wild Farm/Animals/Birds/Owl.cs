using System.Collections.Generic;
using _04._Wild_Farm.Foods;

namespace _04._Wild_Farm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double WeightModifier = 0.25;
        private static HashSet<string> owlAllowedFoods = new HashSet<string>() { nameof(Meat) };

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, owlAllowedFoods, WeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
