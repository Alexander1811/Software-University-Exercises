using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double area = side * side;

                Console.WriteLine($"{area:f3}");
            }
            else if (type == "rectangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());
                double area = side1 * side2;

                Console.WriteLine($"{area:f3}");
            }
            else if (type == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = radius * radius * Math.PI;

                Console.WriteLine($"{area:f3}");
            }
            else if (type == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = side * height * 0.5;

                Console.WriteLine($"{area:f3}");
            }
            else
            {

            }
        }
    }
}
