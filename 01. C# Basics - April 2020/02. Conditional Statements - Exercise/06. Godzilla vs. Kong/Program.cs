using System;

namespace _06._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double costumePrice = double.Parse(Console.ReadLine());

            double clothingPrice = costumePrice * statists;
            double decorPrice = budget * 0.1;

            if (statists > 150)
            {
                clothingPrice *= 0.9;
            }

            double balance = budget - (decorPrice + clothingPrice);
            
            if (balance < 0)
            {
                Console.WriteLine("Not enough money!");
                balance = Math.Abs(balance);
                Console.WriteLine($"Wingard needs {balance:f2} leva more.");
            }
            else 
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {balance:f2} leva left.");
            }
        }
    }
}
