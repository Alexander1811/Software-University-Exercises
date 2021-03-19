using System;
using System.Linq;

namespace _02._Warships
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] mineOffsetsRows = new int[9] { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
                int[] mineOffsetsColumns = new int[9] { -1, 0, 1, -1, 0, 1, -1, 0, 1 };

                int dimension = int.Parse(Console.ReadLine());
                string[] coordinatePairs = Console.ReadLine().Split(',').ToArray();

                char[,] matrix = new char[dimension, dimension];

                int firstPlayerShips = 0;
                int secondPlayerShips = 0;

                for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
                {
                    string[] line = Console.ReadLine().Split(' ').ToArray();
                    for (int currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
                    {
                        matrix[currentRow, currentColumn] = char.Parse(line[currentColumn]);
                        if (matrix[currentRow, currentColumn] == '<')
                        {
                            firstPlayerShips++;
                        }
                        else if (matrix[currentRow, currentColumn] == '>')
                        {
                            secondPlayerShips++;
                        }
                    }
                }

                int firstPlayerShipsInitial = firstPlayerShips;
                int secondPlayerShipsInitial = secondPlayerShips;

                for (int i = 0; firstPlayerShips != 0 && secondPlayerShips != 0 && i < coordinatePairs.Length; i++)
                {
                    int[] currentCoordinates = coordinatePairs[i].Split(' ').Select(int.Parse).ToArray();
                    int row = currentCoordinates[0];
                    int column = currentCoordinates[1];

                    if (!IsPositionValid(row, column, matrix.GetLength(0), matrix.GetLength(1)))
                    {
                        continue;
                    }

                    if (matrix[row, column] == '<')
                    {
                        matrix[row, column] = 'X';
                        firstPlayerShips--;
                    }
                    else if (matrix[row, column] == '>')
                    {
                        matrix[row, column] = 'X';
                        secondPlayerShips--;
                    }
                    else if (matrix[row, column] == '#')
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            int adjecentRow = mineOffsetsRows[j];
                            int adjecentColumn = mineOffsetsColumns[j];

                            if (!IsPositionValid(adjecentRow, adjecentColumn, matrix.GetLength(0), matrix.GetLength(1)))
                            {
                                continue;
                            }

                            else
                            {
                                if (matrix[adjecentRow, adjecentColumn] == '<')
                                {
                                    matrix[adjecentRow, adjecentColumn] = 'X';
                                    firstPlayerShips--;
                                }
                                else if (matrix[adjecentRow, adjecentColumn] == '>')
                                {
                                    matrix[adjecentRow, adjecentColumn] = 'X';
                                    secondPlayerShips--;
                                }
                                else
                                {
                                    matrix[adjecentRow, adjecentColumn] = 'X';
                                }
                            }
                        }
                    }
                }


                int totalCountShipsDestroyed = (firstPlayerShipsInitial - firstPlayerShips) + (secondPlayerShipsInitial - secondPlayerShips);
                if (secondPlayerShips == 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                }
                else if (firstPlayerShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                }
                else
                {
                    Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
                }
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
}