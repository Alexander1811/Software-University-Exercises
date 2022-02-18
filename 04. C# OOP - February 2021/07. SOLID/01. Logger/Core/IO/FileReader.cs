namespace P01_Logger.Core.IO
{
    using System.IO;

    public class FileReader : IReader
    {
        private readonly string[] fileLines;

        private int pointer;

        public FileReader(string path = "../../../input.txt")
        {
            this.fileLines = File.ReadAllLines(path);
        }
        public string ReadLine()
        {
            return this.fileLines[this.pointer++];
        }
    }
}
