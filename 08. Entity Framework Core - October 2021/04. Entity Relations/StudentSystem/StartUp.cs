namespace StudentSystem
{
    using System;

    using Data;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();

            context.Database.EnsureCreated();

            Console.WriteLine("Database created.");

            context.Database.EnsureDeleted();
        }
    }
}
