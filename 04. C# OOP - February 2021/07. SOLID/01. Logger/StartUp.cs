namespace P01_Logger
{
    using P01_Logger.Core;
    using P01_Logger.Core.Factories;
    using P01_Logger.Core.IO;

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
