using System;

namespace P08_HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPricePerNight = 0;
            double apartmantPricePerNight = 0;

            if (month == "May" || month == "October")
            {
                studioPricePerNight = 50;
                apartmantPricePerNight = 65;
            }
            else if (month == "June" || month == "September")
            {
                studioPricePerNight = 75.2;
                apartmantPricePerNight = 68.7;
            }
            else if (month == "July" || month == "August")
            {
                studioPricePerNight = 76;
                apartmantPricePerNight = 77;
            }
            
            if (nights > 7 && (month == "May" || month == "October"))
            {
                if (nights > 14)
                {
                    studioPricePerNight *= 0.7;
                }
                else
                {
                    studioPricePerNight *= 0.95;
                }
            }
            if (nights > 14 && (month == "June" || month == "September"))
            {
                studioPricePerNight *= 0.8;
            }
            if (nights > 14)
            {
                apartmantPricePerNight *= 0.9;
            }

            double totalForStudio = studioPricePerNight * nights;
            double totalForApartment = apartmantPricePerNight * nights;

            Console.WriteLine($"Apartment: {totalForApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalForStudio:f2} lv.");
        }
    }
}
