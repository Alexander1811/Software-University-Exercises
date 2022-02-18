namespace FootballBetting
{
    using System;

    using Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            Console.WriteLine("FootballBetting database created successfully.");
        }
    }
}
