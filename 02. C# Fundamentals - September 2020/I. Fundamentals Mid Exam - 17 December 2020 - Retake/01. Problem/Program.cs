using System;

namespace P01_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());

            double fuelPricePerKilometer = double.Parse(Console.ReadLine()); 

            double foodPricePerPerson = double.Parse(Console.ReadLine()); 

            double roomPricePerPerson = double.Parse(Console.ReadLine()); 
            if (people > 10)
            {
                roomPricePerPerson *= 0.75;
            }

            double foodPrice = people * foodPricePerPerson * days;
            double roomPrice = people * roomPricePerPerson * days;

            double totalExpenses = foodPrice + roomPrice;
            bool isEnough = true;


            for (int day = 1; day <= days; day++)
            {
                double distance = double.Parse(Console.ReadLine());
                double travelPrice = distance * fuelPricePerKilometer;
                totalExpenses += travelPrice;

                if (day % 3 == 0 || day % 5 == 0)
                {
                    totalExpenses *= 1.4;
                }
                if (day % 7 == 0)
                {
                    totalExpenses -= totalExpenses / people;
                }

                if (totalExpenses > budget)
                {
                    isEnough = false;
                    Console.WriteLine($"Not enough money to continue the trip. You need {totalExpenses - budget:f2}$ more.");
                    break;
                }
            }

            if (isEnough)
            {
                Console.WriteLine($"You have reached the destination. You have {budget - totalExpenses:f2}$ budget left.");
            }
        }
    }
}
