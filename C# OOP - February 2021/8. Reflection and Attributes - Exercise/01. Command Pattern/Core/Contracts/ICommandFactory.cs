using _01._Command_Pattern.Contracts;

namespace _01._Command_Pattern.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandType);
    }
}
