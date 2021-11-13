using System;
using System.Linq;

namespace P03_MaximalSum
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

            int highestSum = 0;
            int[] highestSumStartingPair = new int[2];

            int[,] matrix = new int[n, m];

            ReadMatrix(matrix);
            FindHighestSum(ref highestSum, ref highestSumStartingPair, matrix);
            PrintSum(highestSum, highestSumStartingPair, matrix);
        }

        private static void PrintSum(int highestSum, int[] highestSumStartingPair, int[,] matrix)
        {
            Console.WriteLine($"Sum = {highestSum}");
            for (int row = highestSumStartingPair[0]; row < highestSumStartingPair[0] + 3; row++)
            {
                for (int column = highestSumStartingPair[1]; column < highestSumStartingPair[1] + 3; column++)
                {
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine("");
            }
        }

        private static void FindHighestSum(ref int highestSum, ref int[] highestSumStartingPair, int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 2; column++)
                {
                    int currentSum = 0;
                    int[] currentSumStartingPair = new int[2];

                    for (int currentRow = row; currentRow < row + 3; currentRow++)
                    {
                        for (int currentColumn = column; currentColumn < column + 3; currentColumn++)
                        {
                            if (currentRow == row && currentColumn == column)
                            {
                                currentSumStartingPair = new int[2] { currentRow, currentColumn };
                            }
                            currentSum += matrix[currentRow, currentColumn];
                        }
                    }

                    if (currentSum > highestSum)
                    {
                        highestSum = currentSum;
                        highestSumStartingPair = currentSumStartingPair;
                    }
                }
            }
        }

        private static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = rowData[column];
                }
            }
        }
    }
}
