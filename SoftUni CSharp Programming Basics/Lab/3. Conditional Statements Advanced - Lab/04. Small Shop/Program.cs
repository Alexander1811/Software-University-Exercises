using System;

namespace _04._Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Convert.ToString(Console.ReadLine());
            string city = Convert.ToString(Console.ReadLine());
            double amount = Convert.ToDouble(Console.ReadLine());

            if (city == "Sofia")
            {
                if (product == "coffee")
                {
                    double price = amount * 0.5;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    double price = amount * 0.8;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    double price = amount * 1.2;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    double price = amount * 1.45;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    double price = amount * 1.6;
                    Console.WriteLine(price);
                }
            }
            else if (city == "Plovdiv")
            {
                if (product == "coffee")
                {
                    double price = amount * 0.4;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    double price = amount * 0.7;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    double price = amount * 1.15;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    double price = amount * 1.3;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    double price = amount * 1.5;
                    Console.WriteLine(price);
                }
            }
            else if (city == "Varna")
            {
                if (product == "coffee")
                {
                    double price = amount * 0.45;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    double price = amount * 0.7;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    double price = amount * 1.1;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    double price = amount * 1.35;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    double price = amount * 1.55;
                    Console.WriteLine(price);
                }
            }
        }
    }
}
