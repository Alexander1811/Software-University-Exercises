using System.Collections.Generic;

namespace P04_PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string type;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Type = name;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "meat", "veggies", "cheese", "sauce" }, value.ToLower(), $"Cannot place {value} on top of your pizza.");

                this.type = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfValueIsNotInRange(MinWeight, MaxWeight, value, $"{this.Type} weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            return 2 * this.Weight * GetTypeModifier();
        }
        private double GetTypeModifier()
        {
            string type = this.Type.ToLower();
            
            if (type == "meat")
            {
                return 1.2;
            }
            else if (type == "veggies")
            {
                return 0.8;
            }
            else if (type == "cheese")
            {
                return 1.1;
            }
            else //if (type == "sauce")
            {
                return 0.9;
            }
        }
    }
}
