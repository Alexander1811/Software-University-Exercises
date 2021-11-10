namespace P01_Logger.Appenders
{
    using System;

    using P01_Logger.Enums;
    using P01_Logger.Layouts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (this.CanAppend(reportLevel))
            {
                this.MessagesCount++;

                string content = string.Format(this.layout.Template, date, reportLevel, message);

                Console.WriteLine(content);
            }
        }
    }
}
