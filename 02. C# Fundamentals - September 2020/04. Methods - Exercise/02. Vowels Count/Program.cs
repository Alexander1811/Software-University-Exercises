using System;

namespace P02_VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();

            int counter = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char symbol = word[i];

                if (isVowel(symbol))
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        static bool isVowel(char symbol)
        {
            return symbol == 'a' ||
                   symbol == 'o' ||
                   symbol == 'u' ||
                   symbol == 'e' ||
                   symbol == 'i' ||
                   symbol == 'y';
        }
    }
}
