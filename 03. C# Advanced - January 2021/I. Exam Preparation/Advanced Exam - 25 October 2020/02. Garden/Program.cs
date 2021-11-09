using System;
using System.Linq;

namespace P02_Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console
                .ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            int[,] matrix = new int[n, m];

            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                for (int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
                {
                    matrix[currentRow, currentColumn] = 0;
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] plantation = input.Split(" ").Select(int.Parse).ToArray();
                int row = plantation[0];
                int column = plantation[1];
                if (row > matrix.GetLength(0) || column > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
                {
                    matrix[row, currentColumn]++;
                }
                for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
                {
                    if (currentRow != row)
                    {
                        matrix[currentRow, column]++;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
