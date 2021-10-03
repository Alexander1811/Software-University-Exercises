using System;

namespace _04._Beehive_Population
{
    class Program
    {
        static void Main(string[] args)
        {
            int population = int.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());
            int currentYears = 0;

            while (currentYears < years)
            {

                currentYears++; 
                population += (population / 10) * 2;
                if (currentYears % 5 == 0)
                {
                    population -= population / 50 * 5;
                }
                population -= (population / 20) * 2;

                

            }
            Console.WriteLine($"Beehive population: {population}");
        }
    }
}
