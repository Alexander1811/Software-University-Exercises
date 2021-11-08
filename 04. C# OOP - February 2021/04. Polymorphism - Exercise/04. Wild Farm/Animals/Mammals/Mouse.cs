namespace P04WildFarm.Animals.Mammals
{
    using System.Collections.Generic;
    using P04WildFarm.Foods;

    public class Mouse : Mammal
    {
        private const double WeightModifier = 0.10;
        private static readonly HashSet<string> mouseAllowedFoods = new HashSet<string>() { nameof(Vegetable), nameof(Fruit) };

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
