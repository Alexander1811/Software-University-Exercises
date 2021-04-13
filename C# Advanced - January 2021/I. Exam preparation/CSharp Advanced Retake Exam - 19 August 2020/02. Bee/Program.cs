using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MinFlowersCount = 5;

            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;

            bool hasLeft = false;
            int flowersCount = 0;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    field[row, col] = currentRow[col];

                    if (field[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End" && !hasLeft)
            {
                string direction = command;

                int newBeeRow = beeRow;
                int newBeeCol = beeCol;

                GetNewPosition(direction, ref newBeeRow, ref newBeeCol);

                field[beeRow, beeCol] = '.';

                if (!CheckIfCellIsInField(field, newBeeRow, newBeeCol))
                {
                    hasLeft = true;
                    break;
                }
                else
                {
                    if (field[newBeeRow, newBeeCol] == '.')
                    {
                        field[newBeeRow, newBeeCol] = 'B';
                    }
                    else if (field[newBeeRow, newBeeCol] == 'f')
                    {
                        field[newBeeRow, newBeeCol] = 'B';

                        flowersCount++;
                    }
                    else if (field[newBeeRow, newBeeCol] == 'O')
                    {
                        field[newBeeRow, newBeeCol] = '.';

                        GetNewPosition(direction, ref newBeeRow, ref newBeeCol);

                        if (!CheckIfCellIsInField(field, newBeeRow, newBeeCol))
                        {
                            hasLeft = true;
                            break;
                        }
                        else
                        {
                            if (field[newBeeRow, newBeeCol] == '.')
                            {
                                field[newBeeRow, newBeeCol] = 'B';
                            }
                            else if (field[newBeeRow, newBeeCol] == 'f')
                            {
                                field[newBeeRow, newBeeCol] = 'B';

                                flowersCount++;
                            }
                        }
                    }

                    beeRow = newBeeRow;
                    beeCol = newBeeCol;
                }
            }

            if (hasLeft)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (flowersCount < MinFlowersCount)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {MinFlowersCount - flowersCount} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersCount} flowers!");
            }

            PrintMatrix(field);
        }

        private static void GetNewPosition(string command, ref int newRow, ref int newCol)
        {
            switch (command)
            {
                case "up": newRow--; break;
                case "down": newRow++; break;
                case "left": newCol--; break;
                case "right": newCol++; break;
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
