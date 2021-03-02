using System;

namespace _04._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double discount = 0;
            double price = 0;
            double totalPrice = 0;

            if (type == "Roses")
            {
                price = 5 * amount;
            }
            else if (type == "Dahlias")
            {
                price = 3.8 * amount;

            }
            else if (type == "Tulips")
            {
                price = 2.8 * amount;

            }
            else if (type == "Narcissus")
            {
                price = 3 * amount;

            }
            else if (type == "Gladiolus")
            {
                price = 2.5 * amount;

            }


            if (type == "Roses" && amount > 80)
            {
                discount = 0.1 * price;
            }
            else if (type == "Dahlias" && amount > 90)
            {
                discount = 0.15 * price;
            }
            else if (type == "Tulips" && amount > 80)
            {
                discount = 0.15 * price;

            }
            else if (type == "Narcissus" && amount < 120)
            {
                discount = -(0.15 * price);

            }
            else if (type == "Gladiolus" && amount < 80)
            {
               discount = -(0.20 * price);

            }

            if (discount != 0)
            {
                totalPrice = price - discount;
            }
            else
            {
                totalPrice = price;
            }

            double difference = totalPrice - budget;

            if (difference <= 0)
            {
                difference = Math.Abs(difference); 
                Console.WriteLine($"Hey, you have a great garden with {amount} {type} and {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {difference:f2} leva more.");
            }
        }
    }
}
