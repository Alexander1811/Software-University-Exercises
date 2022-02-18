using System;
using System.IO;

namespace P02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("./text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];

                int lettersCount = LettersCount(currentLine);
                int punctuationMarksCount = PunctuationMarksCount(currentLine);

                lines[i] = $"Line {i + 1}: {currentLine} ({lettersCount})({punctuationMarksCount})";
            }

            File.WriteAllLines("../../../output.txt", lines);
        }

        static int LettersCount(string currentLine)
        {
            int count = 0;

            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentCharacter = currentLine[i];
                if (char.IsLetter(currentCharacter))
                {
                    count++;
                }
            }

            return count;
        }
        static int PunctuationMarksCount(string currentLine)
        {
            int count = 0;

            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentCharacter = currentLine[i];
                if (char.IsPunctuation(currentCharacter))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
