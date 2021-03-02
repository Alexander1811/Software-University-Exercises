using System;

namespace _09._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Convert.ToString(Console.ReadLine());
            double sales = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    double commission = sales * 0.05;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double commission = sales * 0.07;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double commission = sales * 0.08;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 10000)
                {
                    double commission = sales * 0.12;
                    Console.WriteLine($"{commission:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    double commission = sales * 0.045;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double commission = sales * 0.075;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double commission = sales * 0.1;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 10000)
                {
                    double commission = sales * 0.13;
                    Console.WriteLine($"{commission:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    double commission = sales * 0.055;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double commission = sales * 0.08;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double commission = sales * 0.12;
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sales > 10000)
                {
                    double commission = sales * 0.145;
                    Console.WriteLine($"{commission:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
