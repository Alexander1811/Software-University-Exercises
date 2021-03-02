using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int value = 1;

            while (n >= value)
            {
                Console.WriteLine(value);
                value = 2 * value + 1;
            }
        }
    }
}
