using System;

namespace _05._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double discount = 0;
            double difference = 0;
            double price = 0;

            if (season == "Spring")
            {
                price = 3000;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                price = 4200;
            }
            else if (season == "Winter")
            {
                price = 2600;
            }

            if (fishermen <= 6)
            {
                discount = 0.1 * price;
            }
            else if (fishermen > 6 && fishermen <= 11)
            {
                discount = 0.15 * price;

            }
            else if (fishermen > 11)
            {
                discount = 0.25 * price;
            }

            if (fishermen % 2 == 0)
            {
                if (season != "Autumn") 
                { 
                    difference = budget - (price - discount) * 0.95;
                }
            }
            else
            {
                difference = budget - (price - discount);
            }

            if (difference >=0)
            {
                Console.WriteLine($"Yes! You have {difference:f2} leva left.");
            }
            else
            {
                difference = Math.Abs(difference);
                Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
            }
        }
    }
}
