namespace _01._Logger.Loggers
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string content);
    }
}
