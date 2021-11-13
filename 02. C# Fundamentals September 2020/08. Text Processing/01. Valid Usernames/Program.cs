using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = Console.ReadLine().Split(", ").ToArray();
            List<string> validUsernames = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                bool hasValidLength = true;
                bool containsOnlyLettersNumbersHyphensAndUnderscores = true;

                string username = lines[i];

                if (username.Length >= 3 && username.Length <= 16)
                {
                    containsOnlyLettersNumbersHyphensAndUnderscores = CheckIf(containsOnlyLettersNumbersHyphensAndUnderscores, username);
                }
                else
                {
                    hasValidLength = false;
                }

                if (hasValidLength && containsOnlyLettersNumbersHyphensAndUnderscores)
                {
                    AddToList(validUsernames, username);
                }
            }

            foreach (string validUsername in validUsernames)
            {
                Console.WriteLine(validUsername);
            }
        }

        private static void AddToList(List<string> validUsernames, string username)
        {
            string validUsername = username.ToString();
            validUsernames.Add(validUsername);
        }

        private static bool CheckIf(bool containsOnlyLettersNumbersHyphensAndUnderscores, string username)
        {
            for (int characterIndex = 0; characterIndex < username.Length; characterIndex++)
            {
                char character = username[characterIndex];
                if (character == '-') //hyphen
                {
                    continue;
                }
                else if (character == '_') //underscore
                {
                    continue;
                }
                else if (character >= 48 && character <= 57) //number
                {
                    continue;
                }
                else if (character >= 65 && character <= 90) //capital letter
                {
                    continue;
                }
                else if (character >= 97 && character <= 122) //noncapital letter
                {
                    continue;
                }
                else
                {
                    containsOnlyLettersNumbersHyphensAndUnderscores = false;
                    break;
                }
            }

            return containsOnlyLettersNumbersHyphensAndUnderscores;
        }
    }
}
