using System;
using System.Linq;
using System.Reflection;
using _01._Command_Pattern.Core.Contracts;

namespace _01._Command_Pattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const string CommandSuffix = "Command";

        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly().
                GetTypes().
                FirstOrDefault(type => type.Name == $"{commandType}{CommandSuffix}");

            if (type == null)
            {
                throw new ArgumentException($"{commandType} is invalid command type.");
            }

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            return instance; 
        }
    }
}
