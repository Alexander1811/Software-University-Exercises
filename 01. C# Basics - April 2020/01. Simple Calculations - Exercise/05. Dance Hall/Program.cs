using System;

namespace _05._Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine()) * 100;
            double width = double.Parse(Console.ReadLine()) * 100;
            double wardrobeSide = double.Parse(Console.ReadLine()) * 100;
           
            double area = length * width;
            double wardrobeArea = wardrobeSide * wardrobeSide;
            double benchArea = area * 0.1;

            double freeArea = area - benchArea - wardrobeArea;

            double numberDancers = Math.Floor(freeArea / 7040);

            Console.WriteLine(numberDancers);
        }
    }
}
