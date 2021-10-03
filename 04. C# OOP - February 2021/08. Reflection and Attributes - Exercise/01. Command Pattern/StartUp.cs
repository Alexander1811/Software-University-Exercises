using _01._Command_Pattern.Core;
using _01._Command_Pattern.Core.Contracts;

namespace _01._Command_Pattern
{
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
