using System;

namespace _10._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int apartmentVolume = length * width * height;
            int takenVolume = 0;

            int boxes;

            string command = Console.ReadLine();

            while (command != "Done")
            {
                boxes = int.Parse(command);
                takenVolume += boxes;
                if (apartmentVolume <= takenVolume)
                {
                    Console.WriteLine($"No more free space! You need {takenVolume - apartmentVolume} Cubic meters more.");
                    break;
                }
                command = Console.ReadLine();
            }
            if (apartmentVolume > takenVolume)
            {
                Console.WriteLine($"{apartmentVolume - takenVolume} Cubic meters left.");
            }
        }
    }
}
