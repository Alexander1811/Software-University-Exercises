namespace Bakery
{
    using Bakery.Core;
    using Bakery.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
