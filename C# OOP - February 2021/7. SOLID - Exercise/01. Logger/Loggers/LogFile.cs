using _01._Logger.Core.IO;
using System.IO;
using System.Linq;

namespace _01._Logger.Loggers
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";

        public int Size => File.ReadAllText(FilePath).Where(character => char.IsLetter(character)).Sum(character => character);

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
