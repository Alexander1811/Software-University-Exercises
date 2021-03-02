using System;

namespace _04._Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i +=2)
            {
                double result = Math.Pow(2,i);
                Console.WriteLine(result);
            }
        }
    }
}
