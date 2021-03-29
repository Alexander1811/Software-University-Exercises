using System.IO;

namespace _01._Logger.Core.IO
{
    class FileWriter : IWriter
    {
        private const string FilePath = "../../../log.txt";

        public void WriteLine(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
