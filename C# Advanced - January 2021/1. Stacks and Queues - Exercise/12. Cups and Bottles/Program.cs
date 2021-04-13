using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            int wastedLitters = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int cup = cups.Peek();

                while (cup > bottles.Peek())
                {
                    cup -= bottles.Pop();

                    if (cup <= 0)
                    {
                        cups.Dequeue();
                    }

                    if (bottles.Count == 0 || cups.Count == 0)
                    {
                        break;
                    }
                }
                if (cup <= bottles.Peek())
                {
                    if (bottles.Count == 0 || cups.Count == 0)
                    {
                        break;
                    }

                    int wastedWater = bottles.Pop() - cup;
                    cups.Dequeue();

                    wastedLitters += wastedWater;
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}
