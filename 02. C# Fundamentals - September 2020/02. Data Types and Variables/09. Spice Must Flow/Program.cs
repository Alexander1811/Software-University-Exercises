using System;

namespace P09_SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int totalSpice = 0;
            int days;

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
