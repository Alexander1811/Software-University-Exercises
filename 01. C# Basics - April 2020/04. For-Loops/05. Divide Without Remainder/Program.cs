using System;

namespace P05_DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1count = 0;
            double p2count = 0;
            double p3count = 0;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    p1count++;
                }
                if (num % 3 == 0)
                {
                    p2count++;
                }
                if (num % 4 == 0)
                {
                    p3count++;
                }
            }

            p1 = p1count / n * 100;
            p2 = p2count / n * 100;
            p3 = p3count / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
