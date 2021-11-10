namespace P04_WildFarm.Animals.Birds
{
    using System.Collections.Generic;

    using P04_WildFarm.Foods;

    public class Hen : Bird
    {
        private const double WeightModifer = 0.35;
        private static readonly HashSet<string> henAllowedFoods = new HashSet<string>() { nameof(Vegetable), nameof(Fruit), nameof(Meat), nameof(Seeds) };

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, henAllowedFoods, WeightModifer, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
