using System;
using System.Linq;

namespace P02_SquaresInMatrix
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
            int rows = dimensions[0];
            int columns = dimensions[1];

            char[,] matrix = new char[rows, columns];
            int squaresCount = 0;

            ReadMatrix(matrix);
            squaresCount = CountSquares(matrix, squaresCount);
            Console.WriteLine(squaresCount);
        }

        private static int CountSquares(char[,] matrix, int squaresCount)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    if (matrix[row, column] == matrix[row, column + 1] && 
                        matrix[row, column] == matrix[row + 1, column] && 
                        matrix[row + 1, column] == matrix[row + 1, column + 1])
                    {
                        squaresCount++;
                    }
                }
            }

            return squaresCount;
        }

        private static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ").ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = char.Parse(rowData[column]);
                }
            }
        }
    }
}
