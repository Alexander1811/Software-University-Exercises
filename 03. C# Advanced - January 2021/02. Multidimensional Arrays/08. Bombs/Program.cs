using System;
using System.Linq;

namespace P08_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string[] bombCoordinatePairs = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int currentBomb = 0; currentBomb < bombCoordinatePairs.Length; currentBomb++)
            {
                int bombRow = int.Parse(bombCoordinatePairs[currentBomb].Split(',')[0]);
                int bombCol = int.Parse(bombCoordinatePairs[currentBomb].Split(',')[1]);

                int bombValue = matrix[bombRow, bombCol];

                for (int count = 1; count <= 9; count++)
                {
                    int neighborRow = -1;
                    int neighborCol = -1;

                    switch (count)
                    {
                        case 1:
                            neighborRow = bombRow - 1;
                            neighborCol = bombCol - 1;
                            break;
                        case 2:
                            neighborRow = bombRow - 1;
                            neighborCol = bombCol;
                            break;
                        case 3:
                            neighborRow = bombRow - 1;
                            neighborCol = bombCol + 1;
                            break;
                        case 4:
                            neighborRow = bombRow;
                            neighborCol = bombCol - 1;
                            break;
                        case 5:
                            neighborRow = bombRow;
                            neighborCol = bombCol;
                            break;
                        case 6:
                            neighborRow = bombRow;
                            neighborCol = bombCol + 1;
                            break;
                        case 7:
                            neighborRow = bombRow + 1;
                            neighborCol = bombCol - 1;
                            break;
                        case 8:
                            neighborRow = bombRow + 1;
                            neighborCol = bombCol;
                            break;
                        case 9:
                            neighborRow = bombRow + 1;
                            neighborCol = bombCol + 1;
                            break;
                        default:
                            break;
                    }

                    if (CheckIfCellIsValid(matrix, neighborRow, neighborCol) && CheckIfCellIsNotDead(matrix, neighborRow, neighborCol))
                    {
                        matrix[neighborRow, neighborCol] -= bombValue;
                    }
                }
            }

            int aliveCellsCount = 0;
            int aliveCellsSum = 0;
            foreach (int cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCellsCount++;
                    aliveCellsSum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintMatrix(matrix);
        }

        private static bool CheckIfCellIsNotDead(int[,] matrix, int row, int col)
        {
            int cell = matrix[row, col];
            
            return !(cell <= 0);
        }

        private static bool CheckIfCellIsValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }

        private static void PrintMatrix(int[,] matrix)
        {
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
