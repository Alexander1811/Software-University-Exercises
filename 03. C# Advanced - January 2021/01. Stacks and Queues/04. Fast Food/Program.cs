using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (food >= 0)
            {
                food -= queue.Dequeue();
                if (!queue.Any())
                {
                    break;
                }
                else if (food - queue.Peek() < 0)
                {
                    break;
                }
            }

            if (!queue.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
            }
        }
    }
}
