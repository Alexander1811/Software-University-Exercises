﻿using System;

namespace P07_NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            NxNMatrix(N);
        }

        static void NxNMatrix(int n)
        {
            for (int columns = 0; columns < n; columns++)
            {
                for (int rows = 0; rows < n; rows++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
