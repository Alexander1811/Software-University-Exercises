using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine().ToLower();

            if (!PasswordLength(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!PasswordOnlyAlphanumeric(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!PasswordWithAtLeastTwoDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (PasswordLength(password) && PasswordOnlyAlphanumeric(password) && PasswordWithAtLeastTwoDigits(password))
            {
                Console.WriteLine("Password is valid");
            }


        }

        static bool PasswordLength(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool PasswordOnlyAlphanumeric(string password)
        {
            foreach (char symbol in password)
            {
                if (!Char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        static bool PasswordWithAtLeastTwoDigits(string password)
        {
            int digitCounter = 0;

            foreach (char symbol in password)
            {
                if (Char.IsDigit(symbol))
                {
                    digitCounter++;
                }
            }

            if (digitCounter < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
