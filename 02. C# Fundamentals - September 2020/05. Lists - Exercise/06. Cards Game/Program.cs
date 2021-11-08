using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(e => int.Parse(e))
                .ToList();
            List<int> secondPlayer = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(e => int.Parse(e))
                .ToList();

            string winner = "";
            int sum = 0;

            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                if (firstPlayer[0] > secondPlayer[0])
                {
                    firstPlayer.Add(firstPlayer[0]);
                    firstPlayer.RemoveAt(0);

                    firstPlayer.Add(secondPlayer[0]);
                    secondPlayer.RemoveAt(0);
                }
                else if (secondPlayer[0] > firstPlayer[0])
                {
                    secondPlayer.Add(secondPlayer[0]);
                    secondPlayer.RemoveAt(0);

                    secondPlayer.Add(firstPlayer[0]);
                    firstPlayer.RemoveAt(0);
                }
                else if (firstPlayer[0] == secondPlayer[0])
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }

                if (firstPlayer.Count == 0)
                {
                    winner = "Second";
                    sum = secondPlayer.Sum();
                    break;
                }
                else if (secondPlayer.Count == 0)
                {
                    winner = "First";
                    sum = firstPlayer.Sum();
                    break;
                }
            }

            Console.WriteLine($"{winner} player wins! Sum: {sum}");
        }
    }
}
