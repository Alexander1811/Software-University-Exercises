using System.Linq;
using _01._Command_Pattern.Core.Contracts;

namespace _01._Command_Pattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;

        public CommandInterpreter()
        {
            this.commandFactory = new CommandFactory();
        }
        public string Read(string args)
        {
            string[] parts = args.Split();

            string commandType = parts[0];
            string[] commandArgs = parts.Skip(1).ToArray();

            ICommand command = this.commandFactory.CreateCommand(commandType);

            return command.Execute(commandArgs);
        }
    }
}
