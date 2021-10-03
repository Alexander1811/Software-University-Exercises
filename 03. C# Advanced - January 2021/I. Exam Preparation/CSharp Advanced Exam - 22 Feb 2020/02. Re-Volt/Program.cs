using System;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasWin = false;

            int playerRow = 0;
            int playerCol = 0;

            int size = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = currentRow[col];

                    GetPlayerCoordinates(ref playerRow, ref playerCol, matrix, row, col);
                }
            }

            matrix[playerRow, playerCol] = '-';

            for (int index = 0; index < commandsCount; index++)
            {
                string command = Console.ReadLine();

                MovePlayer(matrix, playerRow, playerCol, command);

                if (hasWin == true)
                {
                    break;
                }
            }

            void MovePlayer(char[,] matrixInput, int x, int y, string move)
            {
                if (move == "down")
                {
                    bool isInside = CheckIfPlayerIsInField(matrixInput, x + 1, y);

                    playerRow = isInside == true ? playerRow + 1 : 0;

                    if (matrixInput[playerRow, playerCol] == 'B')
                    {
                        MovePlayer(matrix, playerRow, playerCol, "down");
                    }
                    else if (matrixInput[playerRow, playerCol] == 'T')
                    {
                        MovePlayer(matrix, playerRow, playerCol, "up");
                    }
                    else if (matrixInput[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (move == "up")
                {
                    bool isInside = CheckIfPlayerIsInField(matrixInput, x - 1, y);

                    playerRow = isInside == true ? playerRow - 1 : matrixInput.Length - 1;

                    if (matrixInput[playerRow, playerCol] == 'B')
                    {
                        MovePlayer(matrix, playerRow, playerCol, "up");
                    }
                    else if (matrixInput[playerRow, playerCol] == 'T')
                    {
                        MovePlayer(matrix, playerRow, playerCol, "down");
                    }
                    else if (matrixInput[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (move == "left")
                {
                    bool isInside = CheckIfPlayerIsInField(matrixInput, x, y - 1);

                    playerCol = isInside == true ? playerCol - 1 : matrixInput.Length - 1;

                    if (matrixInput[playerRow, playerCol] == 'B')
                    {
                        MovePlayer(matrix, playerRow, playerCol, "left");
                    }
                    else if (matrixInput[playerRow, playerCol] == 'T')
                    {
                        MovePlayer(matrix, playerRow, playerCol, "right");
                    }
                    else if (matrixInput[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
                else if (move == "right")
                {
                    bool isInside = CheckIfPlayerIsInField(matrixInput, x, y + 1);

                    playerCol = isInside == true ? playerCol + 1 : 0;

                    if (matrixInput[playerRow, playerCol] == 'B')
                    {
                        MovePlayer(matrix, playerRow, playerCol, "right");
                    }
                    else if (matrixInput[playerRow, playerCol] == 'T')
                    {
                        MovePlayer(matrix, playerRow, playerCol, "left");
                    }
                    else if (matrixInput[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        hasWin = true;
                    }
                }
            }


            matrix[playerRow, playerCol] = 'f';

            if (hasWin == false)
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);
        }

        private static bool CheckIfPlayerIsInField(char[,] matrix, int x, int y)
        {
            return x >= 0 && y >= 0 && x < matrix.GetLength(0) && y < matrix.GetLength(1);
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

        private static void GetPlayerCoordinates(ref int playerRow, ref int playerCol, char[,] matrix, int row, int column)
        {
            if (matrix[row, column] == 'f')
            {
                playerRow = row;
                playerCol = column;
            }
        }
    }
}