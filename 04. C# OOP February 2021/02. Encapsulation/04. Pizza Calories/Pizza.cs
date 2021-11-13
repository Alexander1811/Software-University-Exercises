using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_PizzaCalories
{
    public class Pizza
    {
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;

        private const int MinToppingsCount = 0;
        private const int MaxToppingsCount = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfValueIsNotInRange(MinNameLength, MaxNameLength, value.Length, $"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
               
                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MaxToppingsCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [{MinToppingsCount}..{MaxToppingsCount}].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            double doughCalories = this.dough.GetCalories();
            double toppingsCalories = this.toppings.Sum(topping => topping.GetCalories());

            return doughCalories + toppingsCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetCalories():F2} Calories.";
        }
    }
}
