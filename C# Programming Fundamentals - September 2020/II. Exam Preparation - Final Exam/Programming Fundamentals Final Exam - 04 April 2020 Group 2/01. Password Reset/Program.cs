using System;
using System.Linq;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                if (action == "TakeOdd")
                {
                    string newPassword = "";
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newPassword += password[i];
                        }
                    }

                    password = newPassword;
                    Console.WriteLine(password);
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(command[1]);
                    int length = int.Parse(command[2]);
                    if (index > password.Length - 1 || index + length > password.Length)
                    {
                        continue;
                    }//check if valid

                    string removeString = password.Substring(index, length);
                    if (password.Contains(removeString))
                    {
                        int substringIndex = password.IndexOf(removeString);
                        int substringLength = removeString.Length;
                        string startOfString = password.Substring(0, substringIndex);
                        string endOfString = password.Substring(substringIndex + substringLength);
                        string newPassword = startOfString + endOfString;
                        password = newPassword;
                        Console.WriteLine(password);
                    }
                }
                else if (action == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];
                    bool containsSubstring = false;
                    while (password.Contains(substring))
                    {
                        int substringIndex = password.IndexOf(substring);
                        int substringLength = substring.Length;
                        string startOfString = password.Substring(0, substringIndex);
                        string middleOfString = substitute;
                        string endOfString = password.Substring(substringIndex + substringLength);
                        string newPassword = startOfString + middleOfString + endOfString;
                        password = newPassword;
                        containsSubstring = true;
                    }
                    if (containsSubstring)
                    {
                        Console.WriteLine(password);
                    }
                    else if (!containsSubstring)
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
