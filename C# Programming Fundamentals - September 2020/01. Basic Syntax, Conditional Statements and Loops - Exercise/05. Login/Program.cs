using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPassword = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                correctPassword += username[i];
            }

            bool isBlocked = true;

            for (int i = 1; i <= 3; i++)
            {                
                string password = Console.ReadLine();

                if (password == correctPassword)
                {
                    Console.WriteLine($"User {username} logged in.");
                    isBlocked = false;
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorrect password. Try again.");
                }                
            }

            if (isBlocked)
            {
                Console.WriteLine($"User {username} blocked!");
            }
        }
    }
}
