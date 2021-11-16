namespace FootballBetting
{
    using System;

    using Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();

            context.Database.EnsureCreated();

            Console.WriteLine("Database created.");

            context.Database.EnsureDeleted();
        }
    }
}
