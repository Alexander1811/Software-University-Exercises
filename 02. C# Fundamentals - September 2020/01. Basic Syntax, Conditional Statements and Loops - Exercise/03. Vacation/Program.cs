using System;

namespace P03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            string group = Console.ReadLine(); 
            string day = Console.ReadLine();
            

            double singlePersonPrice = 0;
            

            switch (day)
            {
                case "Friday":
                    switch (group)
                    {
                        case "Students": singlePersonPrice = 8.45; break;
                        case "Business": singlePersonPrice = 10.9; break;
                        case "Regular": singlePersonPrice = 15; break;
                    }
                    break;
                case "Saturday":
                    switch (group)
                    {
                        case "Students": singlePersonPrice = 9.8; break;
                        case "Business": singlePersonPrice = 15.6; break;
                        case "Regular": singlePersonPrice = 20; break;
                    }
                    break;
                case "Sunday":
                    switch (group)
                    {
                        case "Students": singlePersonPrice = 10.46; break;
                        case "Business": singlePersonPrice = 16; break;
                        case "Regular": singlePersonPrice = 22.5; break;
                    }
                    break;
                default:
                    break;
            }

            double price = students * singlePersonPrice;


            if (group == "Students" && students >= 30)
            {
                price *= 0.85;
            }
            if (group == "Business" && students >= 100)
            {
                price -= singlePersonPrice * 10;
            }
            if (group == "Regular" && students >= 10 && students <= 20)
            {
                price *= 0.95;
            }


            Console.WriteLine($"Total price: {price:F2}");
        }
    }
}
