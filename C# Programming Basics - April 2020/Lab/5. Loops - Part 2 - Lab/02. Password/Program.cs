using System;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string enteredPass = null;

            while (enteredPass != password)
            {
                enteredPass = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {username}!");
        }
    }
}
