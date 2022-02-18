namespace PlayersAndMonsters.IO
{
    using System;

    using Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string content = Console.ReadLine();

            return content;
        }
    }
}
