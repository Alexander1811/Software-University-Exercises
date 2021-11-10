namespace P01_CommandPattern.Core
{
    using System;

    using P01_CommandPattern.Core.Contracts;

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
