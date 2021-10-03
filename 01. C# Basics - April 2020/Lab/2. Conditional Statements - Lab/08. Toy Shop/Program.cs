using System;

namespace _08._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzlePrice = 2.6;
            double dollPrice = 3;
            double teddyPrice = 4.1;
            double minionPrice = 8.2;
            double truckPrice = 2;

            double excursionPrice = double.Parse(Console.ReadLine());
            int puzzleAmount = int.Parse(Console.ReadLine());
            int dollAmount = int.Parse(Console.ReadLine());
            int teddyAmount = int.Parse(Console.ReadLine());
            int minionAmount = int.Parse(Console.ReadLine());
            int truckAmount = int.Parse(Console.ReadLine());

            double sum = puzzlePrice * puzzleAmount + dollPrice * dollAmount + teddyPrice * teddyAmount + minionPrice * minionAmount + truckPrice * truckAmount;

            int toyAmount = puzzleAmount + dollAmount + teddyAmount + minionAmount + truckAmount;

            if (toyAmount >= 50)
            {
                sum *= 0.75;
                sum -= 0.1 * sum;

                double difference = sum - excursionPrice;

                if (difference >= 0)
                {
                    Console.WriteLine($"Yes! {difference:f2} lv left.");
                }
                else
                {
                    difference = Math.Abs(difference);
                    Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
                }
            }
            else if (toyAmount < 50)
            {
                sum -= 0.1 * sum;

                double difference = sum - excursionPrice;

                if (difference >= 0)
                {
                    Console.WriteLine($"Yes! {difference:f2} lv left.");
                }
                else
                {
                    difference = Math.Abs(difference);
                    Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
                }
            }
        }
    }
}
