namespace P01_Logger.Core.IO
{
    using System.IO;

    class FileWriter : IWriter
    {
        private const string FilePath = "../../../log.txt";

        public void WriteLine(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
