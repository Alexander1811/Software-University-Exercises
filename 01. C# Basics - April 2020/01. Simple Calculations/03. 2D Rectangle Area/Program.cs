using System;

namespace P03_2DRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double length = Math.Abs(x1 - x2);
            double width = Math.Abs(y1 - y2);

            double permieter = 2 * (length + width);
            double area = length * width;

            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{permieter:F2}");
        }
    }
}
