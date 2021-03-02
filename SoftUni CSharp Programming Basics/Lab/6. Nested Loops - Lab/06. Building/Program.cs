using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFloors = int.Parse(Console.ReadLine());
            int numberOfRooms = int.Parse(Console.ReadLine());

            for (int floors = numberOfFloors; floors >= 1; floors--)
            {
                for (int rooms = 1; rooms <= numberOfRooms; rooms++)
                {
                    if (floors == numberOfFloors)
                    {
                        while (rooms <= numberOfRooms)
                        {
                            Console.Write("L" + (rooms - 1 + 10 * numberOfFloors) + " ");
                            rooms++;
                        }
                        break;
                    }
                    if (floors % 2 != 0)
                    {
                        Console.Write("A" + (rooms - 1 + 10 * floors) + " ");
                    }
                    else if (floors % 2 == 0)
                    {
                        Console.Write("O" + (rooms - 1 + 10 * floors) + " ");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }
}
