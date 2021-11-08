using System;

namespace P04_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps;
            int totalSteps = 0;
            string command;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "Going home")
                {
                    steps = int.Parse(Console.ReadLine());

                    totalSteps += steps;

                    if (totalSteps >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine((10000 - totalSteps) + " more steps to reach goal.");
                        break;
                    }
                }

                steps = int.Parse(command);

                totalSteps += steps;

                if (totalSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    break;
                }                
            }        
        }
    }
}
