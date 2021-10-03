using System;

namespace _04._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1count = 0;
            double p2count = 0;
            double p3count = 0;
            double p4count = 0;
            double p5count = 0;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    p1count++;                   
                }
                else if (num >= 200 && num < 400)
                {
                    p2count++;
                }
                else if (num >= 400 && num < 600)
                {
                    p3count++;
                }
                else if (num >= 600 && num < 800)
                {
                    p4count++;
                }
                else if (num >= 800)
                {
                    p5count++;
                }
            }
            p1 = p1count / n * 100;
            p2 = p2count / n * 100;
            p3 = p3count / n * 100;
            p4 = p4count / n * 100;
            p5 = p5count / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
