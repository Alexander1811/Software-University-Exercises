using System;

namespace _03._Template_Pattern
{
    public class Sourdough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }
    }
}
