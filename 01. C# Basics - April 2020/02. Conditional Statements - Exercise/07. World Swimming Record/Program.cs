using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double swimTime = meters * secondsPerMeter;
            double delayTime = Math.Floor(meters / 15) * 12.5;

            double totalTime = swimTime + delayTime;

            if (totalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");

            }
            else
            {
                double needSeconds = totalTime - record;
                Console.WriteLine($"No, he failed! He was {needSeconds:F2} seconds slower.");
            }
        }
    }
}