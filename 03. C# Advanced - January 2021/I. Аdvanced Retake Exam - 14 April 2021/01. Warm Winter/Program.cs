using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Queue<int> scarfes = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfes.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfes.Peek();

                if (hat > scarf)
                {
                    int set = hat + scarf;

                    sets.Add(set);

                    hats.Pop();
                    scarfes.Dequeue();
                }
                else if (hat < scarf)
                {
                    hats.Pop();

                    continue;
                }
                else if (hat == scarf)
                {
                    scarfes.Dequeue();

                    hat++;
                    hats.Pop();
                    hats.Push(hat);
                }
            }

            int maxPriceSet = sets.OrderByDescending(s => s).First();

            Console.WriteLine($"The most expensive set is: {maxPriceSet}");

            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
