using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(" ").ToArray();

            char[,] matrix = new char[size, size];

            int minerRow = -1;
            int minerCol = -1;

            int coalsCount = 0;
            int coalsCollected = 0;

            bool leftMine = false;

            for (int row = 0; row < matrix.GetLength(0); row++) //read cells
            {
                string trimmedRow = Regex.Replace(Console.ReadLine(), " ", "");

                for (int col = 0; col < trimmedRow.Length; col++)
                {
                    matrix[row, col] = trimmedRow[col];

                    if (matrix[row, col] == 's') //get miner
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (matrix[row, col] == 'c') //get coals
                    {
                        coalsCount++;
                    }
                }
            }

            for (int turn = 0; turn < commands.Length; turn++)
            {
                string movement = commands[turn];

                int rowModifier = 0;
                int colModifier = 0;

                switch (movement)
                {
                    case "up":
                        rowModifier = -1;
                        break;
                    case "down":
                        rowModifier = +1;
                        break;
                    case "left":
                        colModifier = -1;
                        break;
                    case "right":
                        colModifier = +1;
                        break;
                }

                if (CheckifCellIsInField(matrix, minerRow + rowModifier, minerCol + colModifier))
                {
                    matrix[minerRow, minerCol] = '*';

                    minerRow += rowModifier;
                    minerCol += colModifier;

                    if (matrix[minerRow, minerCol] == '*')
                    {
                        continue;
                    }
                    else if (matrix[minerRow, minerCol] == 'c')
                    {
                        coalsCollected++;

                        if (coalsCollected == coalsCount)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");

                            leftMine = true;

                            break;
                        }
                    }
                    else if (matrix[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");

                        leftMine = true;

                        break;
                    }
                }
                else
                {
                    continue;
                }
            }

            if (leftMine == false)
            {
                Console.WriteLine($"{coalsCount - coalsCollected} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool CheckifCellIsInField(char[,] matrix, int x, int y)
        {
            return x >= 0 && y >= 0 && x < matrix.GetLength(0) && y < matrix.GetLength(1);
        }
    }
}
