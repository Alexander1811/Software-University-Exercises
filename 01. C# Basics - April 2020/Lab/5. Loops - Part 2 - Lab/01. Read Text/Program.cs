using System;

namespace _01._Read_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int words = 0;

            while (command != "Stop")
            {
                command = Console.ReadLine();
                words++;
            }
            Console.WriteLine(words);
        }
    }
}
