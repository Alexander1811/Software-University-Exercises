using System;

namespace _08._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine()) / 10;
            double width = double.Parse(Console.ReadLine()) / 10;
            double height = double.Parse(Console.ReadLine()) / 10;
            double percent = double.Parse(Console.ReadLine()) * 0.01;

            double volume = (length * width * height) * (1 - percent);

            Console.WriteLine($"{volume:f3}");
        }
    }
}
