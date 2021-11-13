using System.Linq;
namespace P01_CommandPattern.Core
{
    using P01_CommandPattern.Core.Contracts;

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
