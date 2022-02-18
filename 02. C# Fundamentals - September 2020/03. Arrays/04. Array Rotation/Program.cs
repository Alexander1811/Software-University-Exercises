using System;

namespace P04_ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            for (int count = 0; count < n; count++)
            {
                string temp = array[0];

                for (int i = 0; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[array.Length - 1] = temp;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
