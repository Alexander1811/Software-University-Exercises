namespace P01_Logger.Loggers
{
    using System.IO;
    using System.Linq;

    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";

        public int Size => File
            .ReadAllText(FilePath)
            .Where(character => char.IsLetter(character))
            .Sum(character => character);

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
