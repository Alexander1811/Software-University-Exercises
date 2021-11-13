namespace P01_CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string args);
    }
}
