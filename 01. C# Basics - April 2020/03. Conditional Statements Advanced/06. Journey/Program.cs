using System;

namespace P06_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = null;
            string accomodation = null;
            double cost = 0;

            if (season == "summer")
            {
                accomodation = "Camp";
            }
            else if (season == "winter")
            {
                accomodation = "Hotel";
            }

            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        cost = 0.3 * budget;
                        break;
                    case "winter":
                        cost = 0.7 * budget;
                        break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        cost = 0.4 * budget;
                        break;
                    case "winter":
                        cost = 0.8 * budget;
                        break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                accomodation = "Hotel";
                cost = 0.9 * budget;  
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accomodation} - {cost:f2}");
        }
    }
}
