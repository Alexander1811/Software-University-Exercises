using System.Collections.Generic;
using _04._Wild_Farm.Foods;

namespace _04._Wild_Farm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WeightModifer = 0.35;
        private static HashSet<string> henAllowedFoods = new HashSet<string>() { nameof(Vegetable), nameof(Fruit), nameof(Meat), nameof(Seeds) };

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
