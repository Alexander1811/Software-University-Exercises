using System;

namespace _07._Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWhiskey = double.Parse(Console.ReadLine());
            double priceRakia = priceWhiskey * 0.5;
            double priceWine = priceRakia * 0.6;
            double priceBeer = priceRakia * 0.2;

            double beerSum = double.Parse(Console.ReadLine()) * priceBeer;
            double wineSum = double.Parse(Console.ReadLine()) * priceWine;
            double rakiaSum = double.Parse(Console.ReadLine()) * priceRakia;
            double whiskeySum = double.Parse(Console.ReadLine()) * priceWhiskey;
            
            double sum = whiskeySum + rakiaSum + wineSum + beerSum;

            Console.WriteLine($"{sum:f2}");
        }
    }
}
