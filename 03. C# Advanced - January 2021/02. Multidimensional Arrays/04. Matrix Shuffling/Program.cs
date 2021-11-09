using System;
using System.Linq;

namespace P04_MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            string[,] matrix = new string[n, m];

            ReadMatrix(matrix);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                string action = command[0];
                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                if (row1 > matrix.GetLength(0) || 
                    col1 > matrix.GetLength(1) || 
                    row2 > matrix.GetLength(0) || 
                    col2 > matrix.GetLength(1) || 
                    action != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                SwapCells(matrix, row1, col1, row2, col2);
                PrintMatrix(matrix);
            }
        }

        private static void SwapCells(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            var num1 = matrix[row1, col1];
            var num2 = matrix[row2, col2];

            matrix[row1, col1] = num2;
            matrix[row2, col2] = num1;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine("");
            }
        }

        private static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = rowData[column];
                }
            }
        }
    }
}
