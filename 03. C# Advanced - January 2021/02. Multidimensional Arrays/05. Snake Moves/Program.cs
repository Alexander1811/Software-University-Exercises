using System;
using System.Linq;

namespace P05_SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            char[,] matrix = new char[n, m];
            string snake = "";

            snake = GetSnake(n, m, snake);
            snake = FillMatrix(matrix, snake);
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
                Console.WriteLine("");
            }
        }

        private static string FillMatrix(char[,] matrix, string snake)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        matrix[row, column] = snake[0];
                        snake = snake.Remove(0, 1);
                    }
                }
                else if (row % 2 != 0)
                {
                    for (int column = matrix.GetLength(1) - 1; column >= 0; column--)
                    {
                        matrix[row, column] = snake[0];
                        snake = snake.Remove(0, 1);
                    }
                }
            }

            return snake;
        }

        private static string GetSnake(int n, int m, string snake)
        {
            string snakePattern = Console.ReadLine();
            double repetitions = Math.Ceiling(n * m / (double)snakePattern.Length);

            for (int i = 0; i < repetitions; i++)
            {
                snake += snakePattern;
            }

            return snake;
        }
    }
}
