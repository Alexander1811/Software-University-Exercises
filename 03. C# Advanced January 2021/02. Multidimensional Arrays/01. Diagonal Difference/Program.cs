using System;
using System.Linq;

namespace P01_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int primarySum = 0;
            int secondarySum = 0;

            ReadMatrix(matrix);
            FindSums(n, matrix, ref primarySum, ref secondarySum);

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }

        private static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = rowData[column];
                }
            }
        }

        private static void FindSums(int n, int[,] matrix, ref int primarySum, ref int secondarySum)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (row - column == 0)
                    {
                        primarySum += matrix[row, column];
                    }
                    if (column + row == n - 1)
                    {
                        secondarySum += matrix[row, column];
                    }
                }
            }
        }
    }
}
