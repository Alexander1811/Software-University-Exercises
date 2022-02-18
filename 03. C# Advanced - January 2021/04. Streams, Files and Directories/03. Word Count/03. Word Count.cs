using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsInTextWithPunctuationMarks = File.ReadAllText("./text.txt");
            wordsInTextWithPunctuationMarks = RemovePunctuationMarksAndToLower(wordsInTextWithPunctuationMarks);
            string[] wordsInText = wordsInTextWithPunctuationMarks.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] wordsToCount = File.ReadAllLines("./words.txt").ToArray();

            Dictionary<string, int> result = new Dictionary<string, int>();
            CountWords(wordsInText, wordsToCount, result);

            List<string> actualResult = new List<string>();
            ReadActualResults(result, actualResult);

            List<string> expectedResult = new List<string>();
            ReadExpectedResults(result, expectedResult);

            File.WriteAllLines("../../../actualResult.txt", actualResult);
            File.WriteAllLines("../../../expectedResult.txt", expectedResult);
        }

        private static void ReadActualResults(Dictionary<string, int> result, List<string> actualResult)
        {
            foreach (KeyValuePair<string, int> keyValuePair in result)
            {
                string word = keyValuePair.Key;
                int count = keyValuePair.Value;

                actualResult.Add($"{word} - {count}");
            }
        }
        private static void ReadExpectedResults(Dictionary<string, int> result, List<string> expectedResult)
        {
            result = result.OrderByDescending(b => b.Value).ToDictionary(a => a.Key, b => b.Value);
            foreach (KeyValuePair<string, int> keyValuePair in result)
            {
                string word = keyValuePair.Key;
                int count = keyValuePair.Value;

                expectedResult.Add($"{word} - {count}");
            }
        }

        private static void CountWords(string[] wordsInText, string[] wordsToCount, Dictionary<string, int> result)
        {
            for (int i = 0; i < wordsToCount.Length; i++)
            {
                string currentWordToCount = wordsToCount[i];
                int count = 0;

                for (int j = 0; j < wordsInText.Length; j++)
                {
                    string currentWordInText = wordsInText[j];

                    if (currentWordInText == currentWordToCount)
                    {
                        count++;
                    }
                }

                result[currentWordToCount] = count;
            }
        }

        static string RemovePunctuationMarksAndToLower(string wordsInTextWithPunctuationMarks)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < wordsInTextWithPunctuationMarks.Length; i++)
            {
                char currentCharacter = wordsInTextWithPunctuationMarks[i];
                char[] marksToReplace = { '-', ',', '.', '!', '?' };

                if (marksToReplace.Contains(currentCharacter))
                {
                    continue;
                }
                else if (currentCharacter == '\n' || currentCharacter == '\r')
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(currentCharacter);
                }
            }

            string text = sb.ToString().Trim();
            text = text.ToLower();

            return text;
        }
    }
}
