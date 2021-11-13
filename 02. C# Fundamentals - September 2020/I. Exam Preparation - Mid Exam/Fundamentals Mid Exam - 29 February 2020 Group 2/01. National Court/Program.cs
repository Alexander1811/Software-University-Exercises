using System;

namespace P01_NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int sumEfficiencyPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;

            int people = int.Parse(Console.ReadLine());
            
            int timeNeeded = 0;
            int days = 0;

            while (people > 0)
            {
                people -= sumEfficiencyPerHour;
                timeNeeded++;
                if (timeNeeded % 4 == 0 && timeNeeded != 0)
                {
                    timeNeeded++;
                    if (timeNeeded >= 24)
                    {
                        days++;
                        timeNeeded -= - 24;
                    }
                }
            }

            Console.WriteLine($"Time needed: {timeNeeded}h.");
        }
    }
}
