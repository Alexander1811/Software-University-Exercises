using System.Collections.Generic;

namespace P04_PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get => this.flourType;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "white", "wholegrain" }, value.ToLower(), "Invalid type of dough.");

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "crispy", "chewy", "homemade" }, value.ToLower(), "Invalid type of dough.");

                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfValueIsNotInRange(MinWeight, MaxWeight, value, $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            return 2 * this.Weight * this.GetFlourTypeModifier() * this.GetBakingTechniqueModifier();
        }

        private double GetFlourTypeModifier()
        {
            string flourTypeLower = this.FlourType.ToLower();

            if (flourTypeLower == "white")
            {
                return 1.5;
            }
            else //if (flourTypeLower == "wholegrain")
            {
                return 1.0;
            }
        }
        private double GetBakingTechniqueModifier()
        {
            string bakingTechniqueLower = this.BakingTechnique.ToLower();

            if (bakingTechniqueLower == "crispy")
            {
                return 0.9;
            }
            else if (bakingTechniqueLower == "chewy")
            {
                return 1.1;
            }
            else //if (bakingTechnique == "homemade")
            {
                return 1.0;
            }
        }
    }
}
