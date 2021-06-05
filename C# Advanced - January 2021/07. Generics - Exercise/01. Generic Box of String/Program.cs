using System;

namespace _01._Generic_Box_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                Console.WriteLine(box);
            }
        }
    }
}
