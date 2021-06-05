using System;
using _01._Logger.Enums;
using _01._Logger.Layouts;
using _01._Logger.Loggers;

namespace _01._Logger.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (this.CanAppend(reportLevel))
            {
                this.MessagesCount++;

                string content = string.Format(this.layout.Template, date, reportLevel, message) + Environment.NewLine;

                this.logFile.Write(content);
            }           
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }
    }
}
