using System;
using System.Linq;

namespace P06_JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[n][];

            ReadMatrix(n, jaggedMatrix);
            AnalyzeMatrix(n, jaggedMatrix);
            ManipulateMatrix(n, jaggedMatrix);
            PrintMatrix(n, jaggedMatrix);
        }

        private static void PrintMatrix(int n, double[][] jaggedMatrix)
        {
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[row]));
            }
        }

        private static void ManipulateMatrix(int n, double[][] jaggedMatrix)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                int rowIndex = int.Parse(command[1]);
                int columnIndex = int.Parse(command[2]);
                double value = double.Parse(command[3]);

                bool isInvalid = rowIndex < 0 || 
                    columnIndex < 0 || 
                    rowIndex >= n || 
                    columnIndex >= jaggedMatrix[rowIndex].Length;
                if (isInvalid)
                {
                    continue;
                }

                if (action == "Add")
                {
                    jaggedMatrix[rowIndex][columnIndex] += value;
                }
                else if (action == "Subtract")
                {
                    jaggedMatrix[rowIndex][columnIndex] -= value;
                }
            }
        }

        private static void AnalyzeMatrix(int n, double[][] jaggedMatrix)
        {
            for (int row = 0; row < n - 1; row++)
            {
                if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                {
                    jaggedMatrix[row] = jaggedMatrix[row].Select(e => e * 2).ToArray();
                    jaggedMatrix[row + 1] = jaggedMatrix[row + 1].Select(e => e * 2).ToArray();
                }
                else
                {
                    jaggedMatrix[row] = jaggedMatrix[row].Select(e => e / 2).ToArray();
                    jaggedMatrix[row + 1] = jaggedMatrix[row + 1].Select(e => e / 2).ToArray();
                }
            }
        }

        private static void ReadMatrix(int n, double[][] jaggedMatrix)
        {
            for (int i = 0; i < n; i++)
            {
                double[] row = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                jaggedMatrix[i] = row;
            }
        }
    }
}
