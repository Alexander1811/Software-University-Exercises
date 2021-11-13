namespace P01_CommandPattern.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
