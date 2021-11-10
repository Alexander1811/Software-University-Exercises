namespace P01_Logger.Core.IO
{
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }
}
