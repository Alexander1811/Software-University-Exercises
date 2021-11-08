namespace P04WildFarm.Animals.Birds
{
    using System.Collections.Generic;
    using P04WildFarm.Foods;

    public class Owl : Bird
    {
        private const double WeightModifier = 0.25;
        private static readonly HashSet<string> owlAllowedFoods = new HashSet<string>() { nameof(Meat) };

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
