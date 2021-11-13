using System;

namespace P02_Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int sellerRow = 0;
            int sellerColumn = 0;

            bool hasPillars = false;
            int entranceRow = -1;
            int entranceColumn = -1;

            bool hasExited = false;
            int exitRow = -1;
            int exitColumn = -1;

            int money = 0;

            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                string line = Console.ReadLine();
                for (int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
                {
                    matrix[currentRow, currentColumn] = line[currentColumn];
                    if (matrix[currentRow, currentColumn] == 'S')
                    {
                        sellerRow = currentRow;
                        sellerColumn = currentColumn;
                    }
                    else if (!hasPillars && matrix[currentRow, currentColumn] == 'O')
                    {
                        entranceRow = currentRow;
                        entranceColumn = currentColumn;
                        hasPillars = true;
                    }

                    if (hasPillars && (matrix[currentRow, currentColumn] == 'O'))
                    {
                        exitRow = currentRow;
                        exitColumn = currentColumn;
                    }
                }
            }

            while (true)
            {
                string movement = Console.ReadLine();

                matrix[sellerRow, sellerColumn] = '-';

                int lastRow = sellerRow;
                int lastColumn = sellerColumn;

                sellerRow = MoveRow(sellerRow, movement);
                sellerColumn = MoveColumn(sellerColumn, movement);

                if (!IsPositionValid(sellerRow, sellerColumn, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[lastRow, lastColumn] = '-';
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (Char.IsDigit(matrix[sellerRow, sellerColumn]))
                {
                    money += matrix[sellerRow, sellerColumn] -48;
                    if (money >= 50)
                    {
                        Console.WriteLine("Good news! You succeeded in collecting enough money!");
                        matrix[sellerRow, sellerColumn] = 'S';
                        break;
                    }
                }

                if (!hasExited)
                {
                    if (hasPillars)
                    {
                        if (sellerRow == entranceRow && sellerColumn == entranceColumn)
                        {
                            sellerRow = exitRow;
                            sellerColumn = exitColumn;

                            matrix[entranceRow, entranceColumn] = '-';
                        }
                        else if (sellerRow == exitRow && sellerColumn == exitColumn)
                        {
                            sellerRow = entranceRow;
                            sellerColumn = entranceColumn;

                            matrix[exitRow, exitColumn] = '-';
                        }
                    }

                    matrix[sellerRow, sellerColumn] = 'S';
                }
            }

            Console.WriteLine($"Money: {money}");
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