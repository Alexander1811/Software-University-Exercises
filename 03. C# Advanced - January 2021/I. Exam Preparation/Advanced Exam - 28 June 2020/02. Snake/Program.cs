using System;

namespace P02_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRow = 0;
            int snakeColumn = 0;

            bool hasBurrow = false;
            int entranceRow = -1;
            int entranceColumn = -1;

            bool hasExited = false;
            int exitRow = -1;
            int exitColumn = -1;

            int foodCounter = 0;

            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                string line = Console.ReadLine();
                for (int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
                {
                    matrix[currentRow, currentColumn] = line[currentColumn];
                    if (matrix[currentRow, currentColumn] == 'S')
                    {
                        snakeRow = currentRow;
                        snakeColumn = currentColumn;
                    }
                    else if (!hasBurrow && matrix[currentRow, currentColumn] == 'B')
                    {
                        entranceRow = currentRow;
                        entranceColumn = currentColumn;
                        hasBurrow = true;
                    }

                    if (hasBurrow && (matrix[currentRow, currentColumn] == 'B'))
                    {
                        exitRow = currentRow;
                        exitColumn = currentColumn;
                    }
                }
            }

            while (true)
            {
                string movement = Console.ReadLine();

                matrix[snakeRow, snakeColumn] = '.';

                int lastRow = snakeRow;
                int lastColumn = snakeColumn;

                snakeRow = MoveRow(snakeRow, movement);
                snakeColumn = MoveColumn(snakeColumn, movement);

                if (!IsPositionValid(snakeRow, snakeColumn, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[lastRow, lastColumn] = '.';
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeColumn] == '*')
                {
                    foodCounter++;
                    if (foodCounter >= 10)
                    {
                        Console.WriteLine("You won! You fed the snake.");
                        matrix[snakeRow, snakeColumn] = 'S';
                        break;
                    }
                }

                if (!hasExited)
                {
                    if (hasBurrow)
                    {
                        if (snakeRow == entranceRow && snakeColumn == entranceColumn)
                        {
                            snakeRow = exitRow;
                            snakeColumn = exitColumn;

                            matrix[entranceRow, entranceColumn] = '.';
                        }
                        else if (snakeRow == exitRow && snakeColumn == exitColumn)
                        {
                            snakeRow = entranceRow;
                            snakeColumn = entranceColumn;

                            matrix[exitRow, exitColumn] = '.';
                        }
                    }

                    matrix[snakeRow, snakeColumn] = 'S';
                }

            }

            Console.WriteLine($"Food eaten: {foodCounter}");
            PrintMatrix(matrix);

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
    }
}
