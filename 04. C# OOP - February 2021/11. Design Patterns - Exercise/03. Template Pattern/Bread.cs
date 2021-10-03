using System;

namespace _03._Template_Pattern
{
    public abstract class Bread
    {
        public abstract void MixIngredients();

        public abstract void Bake(); 
        
        public virtual void Slice()
        {
            Console.WriteLine("Slicing the " + this.GetType().Name + " bread!");
        }

        // The template method:
        public void Make()
        {
            this.MixIngredients(); 
            this.Bake(); 
            this.Slice();
        }
    }
}
