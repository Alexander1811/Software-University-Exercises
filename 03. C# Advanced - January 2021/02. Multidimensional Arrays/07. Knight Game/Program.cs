using System;

namespace P07_KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] chessboard = new char[n, n];
            int knightsCount = 0;
            int[] knightCoordinates = new int[2];

            ReadChessboard(chessboard);

            while (true)
            {
                int maxEnemiesCount = 0;
                for (int row = 0; row < chessboard.GetLength(0); row++)
                {
                    for (int column = 0; column < chessboard.GetLength(1); column++)
                    {
                        char currentCharacter = chessboard[row, column];
                        int currentEnemiesCount = 0;

                        if (currentCharacter == 'K')
                        {
                            currentEnemiesCount = CountEnemies(chessboard, row, column, currentEnemiesCount);
                        }

                        GetKnightCoordinates(ref knightCoordinates, ref maxEnemiesCount, row, column, currentEnemiesCount);
                    }
                }

                if (maxEnemiesCount > 0)
                {
                    chessboard[knightCoordinates[0], knightCoordinates[1]] = 'O';
                    knightsCount++;
                }
                else if (maxEnemiesCount <= 0)
                {
                    Console.WriteLine(knightsCount);
                    break;
                }
            }
        }

        private static void GetKnightCoordinates(ref int[] knightCoordinates, ref int maxEnemiesCount, int row, int column, int currentEnemiesCount)
        {
            if (currentEnemiesCount > maxEnemiesCount)
            {
                maxEnemiesCount = currentEnemiesCount;
                knightCoordinates = new int[2] { row, column };
            }
        }

        private static int CountEnemies(char[,] chessboard, int row, int column, int currentEnemiesCount)
        {
            if (IsInside(chessboard, row - 1, column + 2) 
                && chessboard[row - 1, column + 2] == 'K')
            {
                currentEnemiesCount++;
            }
            if (IsInside(chessboard, row - 1, column - 2) && 
                chessboard[row - 1, column - 2] == 'K')
            {
                currentEnemiesCount++;
            }
            if (IsInside(chessboard, row + 1, column + 2) && 
                chessboard[row + 1, column + 2] == 'K')
            {
                currentEnemiesCount++;
            }
            if (IsInside(chessboard, row + 1, column - 2) && 
                chessboard[row + 1, column - 2] == 'K')
            {
                currentEnemiesCount++;
            }
            if (IsInside(chessboard, row - 2, column + 1) && 
                chessboard[row - 2, column + 1] == 'K')
            {
                currentEnemiesCount++;
            }
            if (IsInside(chessboard, row - 2, column - 1) && 
                chessboard[row - 2, column - 1] == 'K')
            {
                currentEnemiesCount++;
            }
            if (IsInside(chessboard, row + 2, column + 1) && 
                chessboard[row + 2, column + 1] == 'K')
            {
                currentEnemiesCount++;
            }
            if (IsInside(chessboard, row + 2, column - 1) && 
                chessboard[row + 2, column - 1] == 'K')
            {
                currentEnemiesCount++;
            }

            return currentEnemiesCount;
        }

        private static void ReadChessboard(char[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int column = 0; column < chessboard.GetLength(1); column++)
                {
                    chessboard[row, column] = rowData[column];
                }
            }
        }

        private static bool IsInside(char[,] chessboard, int row, int column)
        {
            return row >= 0 && 
                row < chessboard.GetLength(0) && 
                column >= 0 && 
                column < chessboard.GetLength(1);
        }
    }
}
