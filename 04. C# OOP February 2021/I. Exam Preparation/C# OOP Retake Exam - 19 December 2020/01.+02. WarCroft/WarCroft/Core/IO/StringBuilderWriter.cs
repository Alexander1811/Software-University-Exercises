namespace WarCroft.Core.IO
{
    using System.Text;

    using Contracts;

    public class StringBuilderWriter : IWriter
    {
        public StringBuilder sb = new StringBuilder();

        public void WriteLine(string message)
        {
            sb.AppendLine(message);
        }
    }
}
