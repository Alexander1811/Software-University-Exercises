﻿using System;

namespace Generics___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }
        }
    }
}
