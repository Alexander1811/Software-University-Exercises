namespace P04WildFarm.Animals.Mammals
{
    using System.Collections.Generic;
    using P04WildFarm.Foods;

    public class Cat : Feline
    {
        private const double WeightModifer = 0.30;
        private static HashSet<string> catAllowedFoods = new HashSet<string>() { nameof(Meat), nameof(Vegetable) };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, catAllowedFoods, WeightModifer, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
