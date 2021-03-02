using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split();
            string[] array2 = Console.ReadLine().Split();
            string result = String.Empty;

            foreach (string word1 in array2)
            {
                foreach (string word2 in array1)
                {
                    if (word1 == word2)
                    {
                        result += word1 + " ";
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
