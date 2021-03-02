using System;

namespace _08._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Convert.ToString(Console.ReadLine());
            string day = Convert.ToString(Console.ReadLine());
            double amount = double.Parse(Console.ReadLine());

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    double price = amount * 2.5;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "apple")
                {
                    double price = amount * 1.2;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "orange")
                {
                    double price = amount * 0.85;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    double price = amount * 1.45;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "kiwi")
                {
                    double price = amount * 2.7;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "pineapple")
                {
                    double price = amount * 5.5;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "grapes")
                {
                    double price = amount * 3.85;
                    Console.WriteLine($"{price:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana")
                {
                    double price = amount * 2.7;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "apple")
                {
                    double price = amount * 1.25;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "orange")
                {
                    double price = amount * 0.9;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    double price = amount * 1.6;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "kiwi")
                {
                    double price = amount * 3;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "pineapple")
                {
                    double price = amount * 5.6;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "grapes")
                {
                    double price = amount * 4.2;
                    Console.WriteLine($"{price:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
