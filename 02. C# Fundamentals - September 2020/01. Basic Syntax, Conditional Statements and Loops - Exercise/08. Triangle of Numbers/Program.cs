﻿using System;

namespace _08._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int rows = 1; rows < num+1; rows++)
            {
                for (int columns = 0; columns < rows; columns++)
                {
                    Console.Write(rows + " ");
                }
                Console.WriteLine("");
            }        
        }
    }
}
