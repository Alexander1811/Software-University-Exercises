﻿using System;

namespace P04_CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];
                character += (char)3;

                result += character;
            }

            Console.WriteLine(result);
        }
    }
}
