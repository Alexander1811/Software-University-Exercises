using System;

namespace _04._Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginningNum = int.Parse(Console.ReadLine());
            int endingNum = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = beginningNum; i <= endingNum; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine("");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
