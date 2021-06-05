using System;

namespace _03._Template_Pattern
{
    public class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-Grain Bread.");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }
    }
}
