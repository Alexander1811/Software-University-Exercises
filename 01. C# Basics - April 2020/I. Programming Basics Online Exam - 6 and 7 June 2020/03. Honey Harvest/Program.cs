using System;

namespace _03._Honey_Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double bonus = 0;
            if (season == "Summer")
            {
                bonus = 1.1;
            }
            else if (season == "Autumn")
            {
                bonus = 0.95;
            }
            else if (season == "Spring" && type == "Daisy" || type == "Mint")
            {
                bonus = 1.1;
            }
            else
            {
                bonus = 1;
            }

            double honey = 0;
            if (season == "Spring")
            {
                if (type == "Sunflower")
                {
                    honey = amount * 10;
                }
                else if (type == "Daisy")
                {
                    honey = amount * 12;
                }
                else if (type == "Lavander")
                {
                    honey = amount * 12;
                }
                else if (type == "Mint")
                {
                    honey = amount * 10;
                }
            }
            if (season == "Summer")
            {
                if (type == "Sunflower")
                {
                    honey = amount * 8;
                }
                else if (type == "Daisy")
                {
                    honey = amount * 8;
                }
                else if (type == "Lavander")
                {
                    honey = amount * 8;
                }
                else if (type == "Mint")
                {
                    honey = amount * 12;
                }
            }
            if (season == "Autumn")
            {
                if (type == "Sunflower")
                {
                    honey = amount * 12;
                }
                else if (type == "Daisy")
                {
                    honey = amount * 6;
                }
                else if (type == "Lavander")
                {
                    honey = amount * 6;
                }
                else if (type == "Mint")
                {
                    honey = amount * 6;
                }
            }

            honey *= bonus;
            Console.WriteLine($"Total honey harvested: {honey:f2}");
        }
    }
}
