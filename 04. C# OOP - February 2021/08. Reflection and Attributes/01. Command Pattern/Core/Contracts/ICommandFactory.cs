namespace P01_CommandPattern.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandType);
    }
}
