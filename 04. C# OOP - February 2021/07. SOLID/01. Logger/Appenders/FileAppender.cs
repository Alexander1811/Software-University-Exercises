namespace P01_Logger.Appenders
{
    using System;

    using P01_Logger.Enums;
    using P01_Logger.Layouts;
    using P01_Logger.Loggers;

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
