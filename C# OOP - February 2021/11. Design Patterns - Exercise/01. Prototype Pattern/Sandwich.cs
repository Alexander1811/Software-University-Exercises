using System;

namespace _01._Prototype_Pattern
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredientList = GetIngrednientList();

            Console.WriteLine("Cloning sandwich with ingredients: {0}", ingredientList);

            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngrednientList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
