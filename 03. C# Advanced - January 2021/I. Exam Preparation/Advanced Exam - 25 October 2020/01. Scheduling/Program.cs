using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int targetTask = int.Parse(Console.ReadLine());
            int killerThread;

            while (true)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentTask == targetTask)
                {
                    killerThread = currentThread;
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (currentThread < currentTask)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {killerThread} killed task {targetTask}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
