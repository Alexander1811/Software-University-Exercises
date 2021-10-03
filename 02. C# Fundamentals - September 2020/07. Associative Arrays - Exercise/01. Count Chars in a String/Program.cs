using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentCharacter = text[i];

                if (currentCharacter!=' ')
                {
                    if (!dictionary.ContainsKey(currentCharacter))
                    {
                        dictionary[currentCharacter] = 1;
                    }
                    else
                    {
                        dictionary[currentCharacter]++;
                    }
                }
            }

            foreach (var keyValuePair in dictionary)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
