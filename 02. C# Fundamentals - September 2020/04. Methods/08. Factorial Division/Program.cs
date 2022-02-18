using System;

namespace P08_FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            Console.WriteLine($"{FactorialDivison(first, second):F2}");
        }

        static double FactorialDivison(double a, double b)
        {
            double factorialA = 1;
            double factorialB = 1;

            for (int i = 1; i <= a; i++)
            {
                factorialA *= i;
            }
            for (int i = 1; i <= b; i++)
            {
                factorialB *= i;
            }
            return factorialA / factorialB;
        }
    }
}
