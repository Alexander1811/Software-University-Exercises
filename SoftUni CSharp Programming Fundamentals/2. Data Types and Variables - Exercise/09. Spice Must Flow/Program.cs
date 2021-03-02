using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int totalSpice = 0;
            int days = 0;

            for (days = 0; yield >= 100; yield -= 10)
            {
                days++;
                totalSpice += yield;
                if (totalSpice - 26 >= 0)
                {
                    totalSpice -= 26;
                }
                else
                {
                    totalSpice = 0;
                    break;
                }
            }
            if (totalSpice - 26 >= 0)
            {
                totalSpice -= 26;
            }
            else
            {
                totalSpice = 0;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
