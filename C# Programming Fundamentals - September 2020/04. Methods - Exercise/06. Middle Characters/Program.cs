using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            MiddleCharacters(text);
        }

        static void MiddleCharacters(string word)
        {
            if (!(word.Length % 2 == 0))
            {
                Console.WriteLine(word[word.Length / 2]);
            }
            else
            {
                Console.WriteLine("" + word[word.Length / 2 - 1] + word[word.Length / 2]);

            }
        }
    }
}
