using System;
using Players_and_Monsters.IO.Contracts;

namespace Players_and_Monsters.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string content = Console.ReadLine();

            return content;
        }
    }
}
