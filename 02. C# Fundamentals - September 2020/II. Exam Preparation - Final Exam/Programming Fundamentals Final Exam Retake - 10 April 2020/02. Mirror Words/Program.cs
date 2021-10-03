using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex pattern = new Regex(@"(@|#{1})(?<wordOne>[A-Za-z]{3,})\1{2}(?<wordTwo>[A-Za-z]{3,})\1");

            MatchCollection hiddenPairs = pattern.Matches(text);

            Dictionary<string, string> validPairs = new Dictionary<string, string>();

            foreach (Match hiddenPair in hiddenPairs)
            {
                string wordOne = hiddenPair.Groups["wordOne"].Value;
                string wordTwo = hiddenPair.Groups["wordTwo"].Value;
                if (wordOne == ReverseString(wordTwo) && wordTwo == ReverseString(wordOne))
                {
                    validPairs[wordOne] = wordTwo;
                }
            }

            if (hiddenPairs.Count <= 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else if(hiddenPairs.Count > 0)
            {
                Console.WriteLine($"{hiddenPairs.Count} word pairs found!");
            }


            if (validPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else if (validPairs.Count > 0)
            {
                List<string> validKeyValuePairs = new List<string>();

                foreach (KeyValuePair<string, string> keyValuePair in validPairs)
                {
                    validKeyValuePairs.Add($"{keyValuePair.Key} <=> {keyValuePair.Value}");
                }
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", validKeyValuePairs));
            }
        }

        public static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
