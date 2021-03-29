using _01._Logger.Core;
using _01._Logger.Core.Factories;
using _01._Logger.Core.IO;

namespace _01._Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IAppenderFactory appenderFactory = new AppenderFactory();
            ILayoutFactory layoutFactory = new LayoutFactory();
            //IReader reader = new ConsoleReader();
            IReader reader = new FileReader();
            IWriter writer = new ConsoleWriter();
            //IWriter writer = new FileWriter();

            IEngine engine = new Engine(appenderFactory, layoutFactory, reader, writer);

            engine.Run();
        }

    }
}
