using System;
using System.Linq;

namespace P02_SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int marioRow = -1;
            int marioCol = -1;

            bool hasDied = false;
            bool savedPrincess = false;

            int n = int.Parse(Console.ReadLine());
            string firstRow = Console.ReadLine();
            int m = firstRow.Length;

            char[,] maze = new char[n, m];

            for (int row = 0; row < n; row++)
            {
                if (row != 0)
                {
                    string currentRow = Console.ReadLine();
                    for (int col = 0; col < currentRow.Length; col++)
                    {
                        maze[row, col] = currentRow[col];

                        if (maze[row, col] == 'M')
                        {
                            marioRow = row;
                            marioCol = col;
                        }
                    }
                }
                else if (row == 0)
                {
                    for (int col = 0; col < firstRow.Length; col++)
                    {
                        maze[row, col] = firstRow[col];

                        if (maze[row, col] == 'M')
                        {
                            marioRow = row;
                            marioCol = col;
                        }
                    }
                }
            }


            while (!hasDied && !savedPrincess)
            {
                string[] command = Console.ReadLine().Split(" ").ToArray();

                char direction = command[0].ToCharArray().First();

                int bowserRow = int.Parse(command[1]);
                int bowserCol = int.Parse(command[2]);
                maze[bowserRow, bowserCol] = 'B';

                int newMarioRow = marioRow;
                int newMarioCol = marioCol;

                GetNewPosition(direction, ref newMarioRow, ref newMarioCol);

                lives--;

                if (CheckIfCellIsInField(maze, newMarioRow, newMarioCol))
                {
                    maze[marioRow, marioCol] = '-';

                    if (maze[newMarioRow, newMarioCol] == '-')
                    {
                        marioRow = newMarioRow;
                        marioCol = newMarioCol;

                        maze[newMarioRow, newMarioCol] = 'M';
                    }
                    else if (maze[newMarioRow, newMarioCol] == 'B')
                    {
                        marioRow = newMarioRow;
                        marioCol = newMarioCol;

                        lives -= 2;

                        if (lives > 0)
                        {
                            maze[newMarioRow, newMarioCol] = 'M';
                        }
                        else
                        {
                            maze[marioRow, marioCol] = 'X';
                            hasDied = true;
                        }
                    }
                    else if (maze[newMarioRow, newMarioCol] == 'P')
                    {
                        maze[newMarioRow, newMarioCol] = '-';
                        savedPrincess = true;
                    }
                }

                if (lives <= 0 && !savedPrincess)
                {
                    maze[marioRow, marioCol] = 'X';
                    hasDied = true;
                }
            }

            if (hasDied)
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }
            else if (savedPrincess)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            PrintMatrix(maze);
        }

        private static void GetNewPosition(char direction, ref int newRow, ref int newCol)
        {
            switch (direction)
            {
                case 'W': newRow--; break;
                case 'S': newRow++; break;
                case 'A': newCol--; break;
                case 'D': newCol++; break;
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
