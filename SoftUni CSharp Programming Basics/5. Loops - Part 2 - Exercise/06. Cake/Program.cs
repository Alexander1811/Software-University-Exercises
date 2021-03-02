using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int size = width * length;

            string command = "";

            int pieces;
            int piecesTaken = 0;

            while (command != "STOP" || piecesTaken <= size)
            {
                command = Console.ReadLine();
                if (command == "STOP")
                {
                    break;
                }
                pieces = int.Parse(command);
                piecesTaken += pieces;
                if (piecesTaken >= size)
                {
                    break;
                }
            }
            if (command == "STOP" && piecesTaken < size)
            {
                Console.WriteLine($"{size - piecesTaken} pieces are left.");
            }
            else if (piecesTaken >= size)
            {
                Console.WriteLine($"No more cake left! You need {piecesTaken - size} pieces more.");
            }
        }
    }
}
