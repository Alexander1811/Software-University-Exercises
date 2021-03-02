using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> textHistory = new Stack<string>();
            textHistory.Push(string.Empty);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();
                string command = input[0];

                if (command == "1") //add text
                {
                    string someString = input[1];
                    string oldText = textHistory.Peek();
                    string newText = oldText + someString;
                    textHistory.Push(newText);
                }
                else if (command == "2") //remove text
                {
                    int count = int.Parse(input[1]);
                    string oldText = textHistory.Peek();
                    int length = oldText.Length - count;
                    string newText = oldText.Substring(0, length);
                    textHistory.Push(newText);
                }
                else if (command == "3") //return char
                {
                    int index = int.Parse(input[1]) - 1;
                    string oldText = textHistory.Peek();
                    char element = oldText[index];
                    Console.WriteLine(element);
                }
                else if (command == "4") //undo 1/2
                {
                    textHistory.Pop();
                }
            }
        }
    }
}
