using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02_EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex digit = new Regex(@"\d");
            MatchCollection digits = digit.Matches(text);

            long coolThresholdSum = digits.Select(a => int.Parse(a.Value)).Aggregate((a, b) => a * b); 

            Regex emoji = new Regex(@"([:]{2}|[*]{2})([A-Z][a-z]{2,})\1");
            MatchCollection emojis = emoji.Matches(text);

            List<string> coolEmojis = new List<string>();

            foreach (Match match in emojis)
            {
                long coolnessEmoji = match.Groups[2].Value.Sum(x => x);

                if (coolnessEmoji > coolThresholdSum)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");

            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            foreach (string match in coolEmojis)
            {
                Console.WriteLine(match);
            }
        }
    }
}
