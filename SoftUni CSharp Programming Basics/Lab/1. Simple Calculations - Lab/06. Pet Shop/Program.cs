using System;

namespace _06._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsNum = int.Parse(Console.ReadLine());
            int otherNum = int.Parse(Console.ReadLine());

            double dogFood = dogsNum * 2.5;
            double otherFood = otherNum * 4;

            double sum = dogFood + otherFood;

            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
