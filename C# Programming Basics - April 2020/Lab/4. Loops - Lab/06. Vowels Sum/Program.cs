using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int value = 0;

            for (int currentIndex = 0; currentIndex < input.Length; currentIndex++)
            {
                switch (input[currentIndex])
                {
                    case 'a': 
                        value += 1; 
                        break;
                    case 'e':
                        value += 2;
                        break;
                    case 'i': 
                        value += 3;
                        break;
                    case 'o': 
                        value += 4;
                        break;
                    case 'u': 
                        value += 5;
                        break;
                }
            }
            Console.WriteLine(value);
        }
    }
}
