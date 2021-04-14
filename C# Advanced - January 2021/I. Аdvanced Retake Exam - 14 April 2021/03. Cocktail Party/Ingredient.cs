using System;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public string Name { get; private set; }

        public int Alcohol { get; private set; }

        public int Quantity { get; private set; }

        public override string ToString()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Ingredient: {this.Name}");
            //sb.AppendLine();
            //sb.AppendLine();
            return $"Ingredient: {this.Name}" +
Environment.NewLine + $"Quantity: {this.Quantity}" +
Environment.NewLine + $"Alcohol: {this.Alcohol}";
        }
    }
}
