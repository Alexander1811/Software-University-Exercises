using System;

namespace P06_ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currentCharacter = input[i];

                int subsequnceLength = 0;

                for (int j = i + 1; j < input.Length; j++)
                {
                    char nextCharacter = input[j];

                    if (currentCharacter == nextCharacter)
                    {
                        subsequnceLength++;
                    }
                    else
                    {
                        break;
                    }
                }

                input = input.Remove(i + 1, subsequnceLength);
            }

            Console.WriteLine(input);
        }
    }
}
