using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());


            for (int i = 0; i < num; i++)
            {

                for (int j = 0; j < num; j++)
                {
                    for (int k = 0; k < num; k++)
                    {
                        char firstLetter = (char)('a' + i);
                        char secondLetter = (char)('a' + j);
                        char thirdLetter = (char)('a' + k);
                        Console.WriteLine("" + firstLetter + secondLetter + thirdLetter);

                    }
                }
            }
        }
    }
}
