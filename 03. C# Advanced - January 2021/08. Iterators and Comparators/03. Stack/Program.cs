using System;
using System.Linq;

namespace P03_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "Push":
                        int[] elements = command.Skip(1).Select(int.Parse).ToArray();
                        myStack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            myStack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, myStack));
            Console.WriteLine(string.Join(Environment.NewLine, myStack));
        }
    }
}
