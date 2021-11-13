using System;
using System.Linq;

namespace P01_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(' ').ToArray();
                string action = command[0];

                if (action == "Translate")
                {
                    char oldCharacter = char.Parse(command[1]);
                    char newCharacter = char.Parse(command[2]);

                    bool containsCharacter = false;
                    if (text.Contains(oldCharacter))
                    {
                        text = text.Replace(oldCharacter, newCharacter);
                        containsCharacter = true;
                    }
                    if (containsCharacter)
                    {
                        Console.WriteLine(text);
                    }
                }
                else if (action == "Includes")
                {
                    string otherString = command[1];
                    if (text.Contains(otherString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "Start")
                {
                    string otherString = command[1];
                    if (text.StartsWith(otherString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (action == "FindIndex")
                {
                    char character = char.Parse(command[1]);
                    int index = text.LastIndexOf(character);
                    Console.WriteLine(index);
                }
                else if (action == "Remove")
                {
                    int startIndex = int.Parse(command[1]);
                    int count = int.Parse(command[2]);

                    text = text.Remove(startIndex, count);

                    Console.WriteLine(text);
                }
            }
        }
    }
}
