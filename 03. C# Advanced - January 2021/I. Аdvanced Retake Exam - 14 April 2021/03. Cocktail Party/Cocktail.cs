using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private Dictionary<string, Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;

            this.ingredients = new Dictionary<string, Ingredient>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int MaxAlcoholLevel { get; private set; }

        public int CurrentAlcoholLevel => this.ingredients.Values.Sum(i => i.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (this.ingredients.Count < this.Capacity && !this.ingredients.ContainsKey(ingredient.Name))
            {
                this.ingredients.Add(ingredient.Name, ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = this.ingredients.Values.FirstOrDefault(p => p.Name == name);

            if (ingredient == null)
            {
                return false;
            }

            return this.ingredients.Remove(ingredient.Name);
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = this.ingredients.Values.FirstOrDefault(p => p.Name == name);

            if (ingredient == null)
            {
                return null;
            }

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            List<Ingredient> sortedIngredients = this.ingredients.Values.OrderByDescending(p => p.Alcohol).ToList();

            Ingredient ingredient = sortedIngredients.FirstOrDefault();

            return ingredient;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (Ingredient ingredient in this.ingredients.Values)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}