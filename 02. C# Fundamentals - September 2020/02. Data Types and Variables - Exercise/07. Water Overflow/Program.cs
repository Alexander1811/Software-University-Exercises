using System;

namespace P07_WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int n = int.Parse(Console.ReadLine());
            int totalUsedCapacity = 0;

            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if (totalUsedCapacity + liters > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    totalUsedCapacity += liters;
                }
            }
            Console.WriteLine(totalUsedCapacity);
        }
    }
}
