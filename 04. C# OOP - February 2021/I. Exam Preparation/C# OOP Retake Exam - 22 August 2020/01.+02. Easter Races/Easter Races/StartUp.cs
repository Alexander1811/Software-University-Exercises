﻿namespace EasterRaces
{
    using Core.Contracts;
    using Core.Entities;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
        }
    }
}
