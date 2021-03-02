using System;
using System.Collections.Generic;
using System.Linq;


namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.
                ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(e => int.Parse(e)).
                ToList();
            int[] bombParameters = Console.
                ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(e => int.Parse(e)).
                ToArray();

            int bombNumber = bombParameters[0];
            int bombPower = bombParameters[1];

            for (int indexOfNumber = 0; indexOfNumber < numbers.Count; indexOfNumber++)
            {
                if (numbers.Contains(bombNumber))
                {
                    DetonateNeighbours(numbers, bombNumber, bombPower);

                    DetonateBomb(numbers, bombNumber);
                }
            }

            SumNumbers(numbers);
        }

        private static void DetonateNeighbours(List<int> numbers, int bombNumber, int bombPower)
        {
            int indexOfBomb = numbers.IndexOf(bombNumber);

            int detonationStart = indexOfBomb - bombPower;
            for (int i = detonationStart; i < indexOfBomb; i++)
            {
                if (i < numbers.Count && i >= 0)
                {
                    numbers[i] = 0;
                }
            }

            int detonationEnd = indexOfBomb + bombPower;
            for (int i = indexOfBomb + 1; i <= detonationEnd; i++)
            {
                if (i < numbers.Count && i >= 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        private static void SumNumbers(List<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }

        private static void DetonateBomb(List<int> numbers, int bombNumber)
        {
            int indexOfBomb = numbers.IndexOf(bombNumber);
            numbers[indexOfBomb] = 0;
        }
    }
}
