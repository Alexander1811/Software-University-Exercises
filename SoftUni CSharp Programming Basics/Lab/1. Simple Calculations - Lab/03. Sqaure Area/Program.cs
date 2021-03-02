using System;

namespace _03._Sqaure_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double area = Math.Pow(side, 2);
            Console.WriteLine(area);
        }
    }
}
