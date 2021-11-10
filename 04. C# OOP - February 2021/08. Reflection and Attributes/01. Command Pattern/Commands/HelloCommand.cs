namespace P01_CommandPattern.Contracts
{
    using P01_CommandPattern.Core.Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
