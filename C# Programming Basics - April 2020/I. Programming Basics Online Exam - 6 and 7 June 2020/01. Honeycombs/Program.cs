using System;

namespace _01._Honeycombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int bees = int.Parse(Console.ReadLine());
            int flowers = int.Parse(Console.ReadLine());

            double honey = 0; 
            double honeycombs = 0;
            double leftHoney = 0;

            honey += 0.21 * bees * flowers; 

            honeycombs = Math.Floor(honey / 100);
            leftHoney = honey % 100; 

            Console.WriteLine($"{honeycombs} honeycombs filled.");
            Console.WriteLine($"{leftHoney:f2} grams of honey left.");
        }
    }
}
