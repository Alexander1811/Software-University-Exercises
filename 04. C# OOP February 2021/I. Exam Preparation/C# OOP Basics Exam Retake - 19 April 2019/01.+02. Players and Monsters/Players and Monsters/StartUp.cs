namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IManagerController managerController = new ManagerController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(managerController, reader, writer);

            engine.Run();
        }
    }
}