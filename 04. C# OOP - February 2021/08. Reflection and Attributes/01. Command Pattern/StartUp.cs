namespace P01_CommandPattern
{
    using P01_CommandPattern.Core;
    using P01_CommandPattern.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);

            engine.Run();
        }
    }
}
