namespace P04WildFarm.Animals.Mammals
{
    using System.Collections.Generic;
    using P04WildFarm.Foods;

    public class Dog : Mammal
    {
        private const double WeightModifier = 0.40;
        private static readonly HashSet<string> dogAllowedFoods = new HashSet<string>() { nameof(Meat) };

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
