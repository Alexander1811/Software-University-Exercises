using System;
using System.Collections.Generic;

namespace P08_BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string expressionCharacters = Console.ReadLine();
            Stack<char> expression = new Stack<char>();

            bool isValid = true;

            if (expressionCharacters.Length % 2 != 0)
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < expressionCharacters.Length; i++)
                {
                    char currentCharacter = expressionCharacters[i];

                    if (currentCharacter == '(' || 
                        currentCharacter == '[' || 
                        currentCharacter == '{')
                    {
                        expression.Push(currentCharacter);
                    }
                    else
                    {
                        if (currentCharacter == ')' && expression.Pop() == '(' || 
                            currentCharacter == ']' && expression.Pop() == '[' || 
                            currentCharacter == '}' && expression.Pop() == '{')
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }

                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
