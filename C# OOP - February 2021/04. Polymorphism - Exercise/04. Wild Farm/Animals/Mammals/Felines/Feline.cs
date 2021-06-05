using System.Collections.Generic;

namespace _04._Wild_Farm.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, HashSet<string> allowedFoods, double weightModifier, string livingRegion, string breed) 
            : base(name, weight, allowedFoods, weightModifier, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
