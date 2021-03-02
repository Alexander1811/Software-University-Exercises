using System;

namespace _04._Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double areaSize = (length + 0.3 * 2) * (width + 0.3 * 2);
            double caretSize = length * length / 4;
            double tableArea = tables * areaSize;
            double caretArea = tables * caretSize;

            double priceUSD = tableArea * 7 + caretArea * 9;
            double priceBGN = priceUSD * 1.85;

            Console.WriteLine($"{priceUSD:f2} USD");
            Console.WriteLine($"{priceBGN:f2} BGN");
        }
    }
}
