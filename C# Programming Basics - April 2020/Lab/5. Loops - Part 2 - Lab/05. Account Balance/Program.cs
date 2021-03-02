using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;

            while (n != 0)
            {
                double increase = double.Parse(Console.ReadLine());
                if (increase >= 0)
                {
                    sum += increase;
                    Console.WriteLine($"Increase: {increase:f2}");
                    n--;
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }
            Console.WriteLine($"Total: {sum}");
        }
    }
}
