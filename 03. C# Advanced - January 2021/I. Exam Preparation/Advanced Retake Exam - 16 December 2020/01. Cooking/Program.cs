using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            const int bread = 25;
            const int cake = 50;
            const int pastry = 75;
            const int fruitPie = 100;

            int breadCounter = 0;
            int cakeCounter = 0;
            int pastryCounter = 0;
            int fruitPieCounter = 0;

            bool hasCookedEnough = false;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Peek();
                int ingredient = ingredients.Peek();
                int sum = liquid + ingredient;
                if (sum == bread || sum == cake || sum == pastry || sum == fruitPie)
                {
                    ingredients.Pop();
                    liquids.Dequeue();

                    if (sum == bread)
                    {
                        breadCounter++;
                    }
                    else if (sum == cake)
                    {
                        cakeCounter++;
                    }
                    else if (sum == pastry)
                    {
                        pastryCounter++;
                    }
                    else if (sum == fruitPie)
                    {
                        fruitPieCounter++;
                    }
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }

                if (breadCounter >= 1 && cakeCounter >= 1 && pastryCounter >= 1 && fruitPieCounter >= 1)
                {
                    hasCookedEnough = true;
                    break;
                }
            }

            if (hasCookedEnough)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            Console.WriteLine($"Bread: {breadCounter}");
            Console.WriteLine($"Cake: {cakeCounter}");
            Console.WriteLine($"Fruit Pie: {fruitPieCounter}");
            Console.WriteLine($"Pastry: {pastryCounter}");
        }
    }
}
