using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> racers = CreateRacersList();

            AddDistanceToRacers(racers);

            Dictionary<string, long> qualified = racers.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, b => b.Value);
            List<string> winners = CreateWinnersList(qualified);

            PrintWinners(winners);
        }

        private static void AddDistanceToRacers(Dictionary<string, long> racers)
        {
            string command;
            while ((command = Console.ReadLine()) != "end of race")
            {
                char[] input = command.ToCharArray();

                string currentName = "";
                long currentSum = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    char currentCharacter = input[i];

                    if (currentCharacter >= 65 && currentCharacter <= 90 || currentCharacter >= 97 && currentCharacter <= 122) //letters
                    {
                        currentName += currentCharacter;
                    }
                    else if (currentCharacter >= 48 && currentCharacter <= 57) //digits
                    {
                        currentSum += currentCharacter - 48;
                    }
                }

                if (racers.ContainsKey(currentName))
                {
                    racers[currentName] += currentSum;
                }
            }
        }

        private static List<string> CreateWinnersList(Dictionary<string, long> qualified)
        {
            List<string> winners = new List<string>();

            foreach (KeyValuePair<string, long> keyValuePair in qualified)
            {
                int i = 1;
                if (i < 3)
                {
                    winners.Add(keyValuePair.Key);
                }
                i++;
            }

            return winners;
        }

        private static void PrintWinners(List<string> winners)
        {
            string first = winners[0];
            string second = winners[1];
            string third = winners[2];

            Console.WriteLine($"1st place: {first} \n2nd place: {second} \n3rd place: {third}");
        }

        private static Dictionary<string, long> CreateRacersList()
        {
            Dictionary<string, long> racers = new Dictionary<string, long>();

            string[] participants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (string participant in participants)
            {
                racers.Add(participant, 0);
            }

            return racers;
        }
    }
}
