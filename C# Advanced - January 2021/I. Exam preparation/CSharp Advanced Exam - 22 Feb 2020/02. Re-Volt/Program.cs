using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[dimension, dimension];

            int playerRow = 0;
            int playerColumn = 0;

            bool hasWon = false;

            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                string line = Console.ReadLine();
                for (int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
                {
                    matrix[currentRow, currentColumn] = line[currentColumn];
                    if (matrix[currentRow, currentColumn] == 'f')
                    {
                        playerRow = currentRow;
                        playerColumn = currentColumn;
                    }
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string movement = Console.ReadLine();

                matrix[playerRow, playerColumn] = '-';

                int lastRow = playerRow;
                int lastColumn = playerColumn;

                playerRow = MoveRow(playerRow, movement);
                playerColumn = MoveColumn(playerColumn, movement);

                if (!IsPositionValid(playerRow, playerColumn, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[lastRow, lastColumn] = '-';
                    playerRow = MoveToTheBottomOrTop(playerRow, matrix.GetLength(0), movement);
                    playerColumn = MoveToTheLeftOrRightEnd(playerColumn, matrix.GetLength(1), movement);
                }

                if (matrix[playerRow, playerColumn] == 'B')
                {
                    playerRow = MoveRow(playerRow, movement);
                    playerColumn = MoveColumn(playerColumn, movement);
                }
                else if (matrix[playerRow, playerColumn] == 'T')
                {
                    movement = ReverseDirection(movement);
                    playerRow = MoveRow(playerRow, movement);
                    playerColumn = MoveColumn(playerColumn, movement);
                }
                else if (matrix[playerRow, playerColumn] == 'F')
                {
                    matrix[playerRow, playerColumn] = 'f';
                    Console.WriteLine("Player won!");
                    hasWon = true;
                    break;
                }

                if (!IsPositionValid(playerRow, playerColumn, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[lastRow, lastColumn] = '-';
                    playerRow = MoveToTheBottomOrTop(playerRow, matrix.GetLength(0), movement);
                    playerColumn = MoveToTheLeftOrRightEnd(playerColumn, matrix.GetLength(1), movement);
                }

                matrix[playerRow, playerColumn] = 'f';
            }
            if (!hasWon)
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);
        }

        private static string ReverseDirection(string movement)
        {
            if (movement == "left")
            {
                movement = "right";
            }
            else if (movement == "right")
            {
                movement = "left";
            }
            else if (movement == "up")
            {
                movement = "down";
            }
            else if (movement == "down")
            {
                movement = "up";
            }

            return movement;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column]);
                }
                Console.WriteLine();
            }
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveColumn(int column, string movement)
        {
            if (movement == "left")
            {
                return column - 1;
            }
            if (movement == "right")
            {
                return column + 1;
            }

            return column;
        }

        public static bool IsPositionValid(int row, int column, int rows, int columns)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (column < 0 || column >= columns)
            {
                return false;
            }

            return true;
        }

        public static int MoveToTheBottomOrTop(int row, int rows, string movement)
        {
            if (movement == "up")
            {
                return row + rows;
            }
            if (movement == "down")
            {
                return row - rows;
            }

            return row;
        }
        public static int MoveToTheLeftOrRightEnd(int column, int columns, string movement)
        {
            if (movement == "left")
            {
                return column + columns;
            }
            if (movement == "right")
            {
                return column - columns;
            }

            return column;
        }
    }
}
