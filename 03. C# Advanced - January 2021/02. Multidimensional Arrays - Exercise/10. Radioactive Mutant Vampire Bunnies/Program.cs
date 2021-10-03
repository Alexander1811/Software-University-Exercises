using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            char[,] field = new char[n, m];

            int playerRow = -1;
            int playerCol = -1;

            bool hasWon = false;
            bool hasDied = false;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];

                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            for (int turn = 0; turn < commands.Length; turn++)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                GetNewPosition(commands, turn, ref newPlayerRow, ref newPlayerCol);

                field[playerRow, playerCol] = '.';

                if (!CheckIfCellIsInField(field, newPlayerRow, newPlayerCol))
                {
                    hasWon = true;

                    SpreadBunnies(GetBunnyCoordinates(field), field);
                }
                else if (field[newPlayerRow, newPlayerCol] == '.')
                {
                    field[newPlayerRow, newPlayerCol] = 'P';

                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    SpreadBunnies(GetBunnyCoordinates(field), field);

                    if (field[playerRow, playerCol] == 'B')
                    {
                        hasDied = true;
                    }
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                    hasDied = true;

                    SpreadBunnies(GetBunnyCoordinates(field), field);
                }

                if (hasWon || hasDied)
                {
                    break;
                }
            }

            PrintMatrix(field);

            if (hasWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (hasDied)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static void SpreadBunnies(List<int[]> bunniesCoordinates, char[,] field)
        {
            foreach (int[] bunnyCoordinates in bunniesCoordinates)
            {
                int bunnyRow = bunnyCoordinates[0];
                int bunnyCol = bunnyCoordinates[1];

                string directions = "UDLR";

                for (int side = 0; side < 4; side++)
                {
                    int newBunnyRow = bunnyRow;
                    int newBunnyCol = bunnyCol;

                    GetNewPosition(directions, side, ref newBunnyRow, ref newBunnyCol);

                    if (CheckIfCellIsInField(field, newBunnyRow, newBunnyCol))
                    {
                        field[newBunnyRow, newBunnyCol] = 'B';
                    }
                }
            }
        }

        private static List<int[]> GetBunnyCoordinates(char[,] field)
        {
            List<int[]> bunnyCoordinates = new List<int[]>();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'B')
                    {
                        bunnyCoordinates.Add(new int[] { row, col });
                    }
                }
            }

            return bunnyCoordinates;
        }

        private static void GetNewPosition(string commands, int i, ref int newRow, ref int newCol)
        {
            switch (commands[i])
            {
                case 'U':
                    newRow--;
                    break;
                case 'D':
                    newRow++;
                    break;
                case 'L':
                    newCol--;
                    break;
                case 'R':
                    newCol++;
                    break;
            }
        }

        private static bool CheckIfCellIsInField(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
