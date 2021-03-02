using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine(Subtract(Sum(first, second), third));
        }

        static int Sum(int a, int b)
        {
            int result = a + b;
            return result;
        }
        static int Subtract(int sum, int c)
        {
            int result = sum - c;
            return result;
        }
    }
}
