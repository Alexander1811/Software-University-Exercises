using System;
using System.Linq;

namespace _04._Pizza_Calories
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] pizzaData = Console.ReadLine().Split(' ').ToArray();
            string pizzaName = pizzaData[1];

            string[] doughData = Console.ReadLine().Split(' ').ToArray();
            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            int weight = int.Parse(doughData[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingData = input.Split(' ').ToArray();

                    string toppingName = toppingData[1];
                    int toppingWeight = int.Parse(toppingData[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);

            }
            catch (Exception ex)
            when (ex is ArgumentException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
