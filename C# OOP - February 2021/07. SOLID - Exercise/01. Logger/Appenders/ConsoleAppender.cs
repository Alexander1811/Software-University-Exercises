using System;
using _01._Logger.Enums;
using _01._Logger.Layouts;

namespace _01._Logger.Appenders
{
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
