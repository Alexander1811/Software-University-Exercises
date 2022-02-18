namespace P04_WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using P04_WildFarm.Foods;

    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFoods, double weightModifier)
        {
            this.Name = name;
            this.Weight = weight;
            this.AllowedFoods = allowedFoods;
            this.WeightModifier = weightModifier;
        }

        private HashSet<string> AllowedFoods { get; set; }

        private double WeightModifier { get; set; }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.AllowedFoods.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;

            this.Weight += food.Quantity * this.WeightModifier;
        }
    }
}
