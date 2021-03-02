using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] marksToReplace = { '-', ',', '.', '!', '?' };

            using (StreamReader reader = new StreamReader("./text.txt"))
            {
                string currentLine;
                int counter = 0;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        currentLine = ReplacePunctuationMarks(marksToReplace, '@', currentLine);
                        currentLine = ReverseWordOrder(currentLine);
                        Console.WriteLine(string.Join(" ", currentLine));
                    }
                }
            }
        }

        private static string ReverseWordOrder(string currentLine)
        {
            StringBuilder sb = new StringBuilder();            
            
            string[] words = currentLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[words.Length - i - 1]);
                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }

        static string ReplacePunctuationMarks(char[] marksToReplace, char newSymbol, string currentLine)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentCharacter = currentLine[i];
                if (marksToReplace.Contains(currentCharacter))
                {
                    sb.Append(newSymbol);
                }
                else
                {
                    sb.Append(currentCharacter);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
