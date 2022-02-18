using System;
using System.Linq;

namespace P03_HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@")
                .Select(x => int.Parse(x))
                .ToArray();
            int cupidsPosition = 0;

            string input;
            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string jump = command[0];
                int length = int.Parse(command[1]);

                cupidsPosition += length;
                if (cupidsPosition > neighborhood.Length - 1)
                {
                    cupidsPosition = 0;
                }

                int houseIndex = cupidsPosition;

                neighborhood[houseIndex] -= 2;
                if (neighborhood[houseIndex] >= -1 && neighborhood[houseIndex] <= 0) 
                {
                    houseIndex = cupidsPosition;
                    Console.WriteLine($"Place {houseIndex} has Valentine's day.");
                }
                else if (neighborhood[houseIndex] < -1)
                {
                    Console.WriteLine($"Place {houseIndex} already had Valentine's day.");
                }
            }

            Console.WriteLine($"Cupid's last position was {cupidsPosition}.");
            if (neighborhood.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int failedHouses = 0;
                foreach (int house in neighborhood)
                {
                    if (house > 0)
                    {
                        failedHouses++;
                    }
                }

                Console.WriteLine($"Cupid has failed {failedHouses} places.");
            }
        }
    }
}
