using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] command = input.Split(":|:").ToArray();
                string action = command[0];
                if (action == "InsertSpace")
                {
                    int index = int.Parse(command[1]);
                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (action == "Reverse")
                {
                    string substring = command[1];
                    if (!message.Contains(substring))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    else
                    {
                        int substringIndex = message.IndexOf(substring);
                        int substringLength = substring.Length;

                        message = message.Remove(substringIndex, substringLength);

                        substring = ReverseString(substring);

                        message = message.Insert(message.Length, substring);

                        Console.WriteLine(message);
                    }
                }
                else if (action == "ChangeAll")
                {
                    string substring = command[1];
                    string replacement = command[2];
                    while (message.Contains(substring))
                    {
                        int substringIndex = message.IndexOf(substring);
                        int substringLength = substring.Length;
                        message = message.Remove(substringIndex, substringLength);
                        message = message.Insert(substringIndex, replacement);
                    }
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        public static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}

