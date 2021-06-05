using System;
using _01._Command_Pattern.Core.Contracts;

namespace _01._Command_Pattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                string result = this.commandInterpreter.Read(command);

                if (result == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
