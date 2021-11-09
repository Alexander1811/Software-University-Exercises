using System;
using System.Linq;

namespace P02_CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = Console.ReadLine().Split(" ").ToArray();
            string first = lines[0];
            string second = lines[1];

            int sum = 0;

            sum = FindSum(first, second, sum);

            Console.WriteLine(sum);
        }

        private static int FindSum(string first, string second, int sum)
        {
            if (first.Length == second.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    sum += first[i] * second[i];
                }
            }
            else if (first.Length < second.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    sum += first[i] * second[i];
                }
                for (int i = first.Length; i < second.Length; i++)
                {
                    sum += second[i];
                }
            }
            else if (first.Length > second.Length)
            {
                for (int i = 0; i < second.Length; i++)
                {
                    sum += first[i] * second[i];
                }
                for (int i = second.Length; i < first.Length; i++)
                {
                    sum += first[i];
                }
            }

            return sum;
        }
    }

}
