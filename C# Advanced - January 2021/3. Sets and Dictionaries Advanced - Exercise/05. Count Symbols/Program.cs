using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> symbols = new Dictionary<char, int>();

            FillDictionary(text, symbols);

            symbols = symbols.OrderBy(a => a.Key).ToDictionary(a => a.Key, b => b.Value);

            PrintDictionary(symbols);
        }

        private static void PrintDictionary(Dictionary<char, int> symbols)
        {
            foreach (KeyValuePair<char, int> item in symbols)
            {
                char symbol = item.Key;
                int count = item.Value;
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }

        private static void FillDictionary(string text, Dictionary<char, int> symbols)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char currentCharacter = text[i];
                if (symbols.ContainsKey(currentCharacter))
                {
                    symbols[currentCharacter]++;
                }
                else
                {
                    symbols[currentCharacter] = 1;
                }
            }
        }
    }
}
