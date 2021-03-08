using System;

namespace _01._Class_Box_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.CalculateArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralArea():F2}");
                Console.WriteLine($"Volume - {box.CalculateVolume():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
