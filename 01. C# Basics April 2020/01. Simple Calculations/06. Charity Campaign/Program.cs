using System;

namespace P06_CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());

            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double priceCakes = cakes * 45;
            double priceWaffles = waffles * 5.80;
            double pricePancakes = pancakes * 3.20;

            double dailyRevenue = (priceCakes + priceWaffles + pricePancakes) * days * bakers;

            double RevenueAfterExpenses = dailyRevenue * 0.875;

            Console.WriteLine($"{RevenueAfterExpenses:f2}");
        }
    }
}
