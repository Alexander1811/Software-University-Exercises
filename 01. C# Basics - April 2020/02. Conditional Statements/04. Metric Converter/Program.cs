using System;

namespace P04_MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double value = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            if (inputUnit == "mm")
            {
                if (outputUnit == "cm")
                {
                    double newValue = value * 0.1;
                    Console.WriteLine($"{newValue:f3}");
                }
                else if (outputUnit == "m")
                {
                    double newValue = value * 0.001;
                    Console.WriteLine($"{newValue:f3}");
                }
            }
            else if (inputUnit == "cm")
            {
                if (outputUnit == "mm")
                {
                    double newValue = value * 10;
                    Console.WriteLine($"{newValue:f3}");
                }
                else if (outputUnit == "m")
                {
                    double newValue = value * 0.01;
                    Console.WriteLine($"{newValue:f3}");
                }
            }
            else if (inputUnit == "m")
            {
                if (outputUnit == "mm")
                {
                    double newValue = value * 1000;
                    Console.WriteLine($"{newValue:f3}");
                }
                else if (outputUnit == "cm")
                {
                    double newValue = value * 100;
                    Console.WriteLine($"{newValue:f3}");
                }
            }
        }
    }
}