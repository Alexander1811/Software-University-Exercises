using System;

namespace _03._Template_Pattern
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Whole Wheat Bread.");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
        }
    }
}
