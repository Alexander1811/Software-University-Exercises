using System;
using System.Linq;

namespace P07_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console
                .ReadLine()
                .Split()
                .Select(e => int.Parse(e))
                .ToArray();

            int longestSequenceLength = 0;
            int longestSequenceIndex = 0;

            string result = "";

            for (int mainIndex = 0; mainIndex < array.Length; mainIndex++)
            {
                int currentIndex = array[mainIndex];
                int currentSequenceLength = 1;

                for (int followingIndex = mainIndex + 1; followingIndex < array.Length; followingIndex++)
                {
                    if (array[mainIndex] == array[followingIndex])
                    {
                        currentSequenceLength++;
                    }
                    else
                    {
                        break;
                    }

                    if (currentSequenceLength > longestSequenceLength)
                    {
                        longestSequenceLength = currentSequenceLength;
                        longestSequenceIndex = currentIndex;
                    }
                }
            }

            for (int i = 0; i < longestSequenceLength; i++)
            {
                result += longestSequenceIndex + " ";
            }
            
            Console.WriteLine(result);
        }
    }
}
