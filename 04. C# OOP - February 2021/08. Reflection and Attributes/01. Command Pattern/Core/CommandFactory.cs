using System;
using System.Linq;
using System.Reflection;
namespace P01_CommandPattern.Core
{
    using P01_CommandPattern.Core.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private const string CommandSuffix = "Command";

        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.Name == $"{commandType}{CommandSuffix}");

            if (type == null)
            {
                throw new ArgumentException($"{commandType} is invalid command type.");
            }

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            return instance;
        }
    }
}
