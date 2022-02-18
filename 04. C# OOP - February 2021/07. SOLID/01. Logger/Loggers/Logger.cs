namespace P01_Logger.Loggers
{
    using System.Text;

    using P01_Logger.Appenders;
    using P01_Logger.Enums;

    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Info, message);
        }

        public void Warning(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Warning, message);
        }

        public void Error(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Error, message);
        }

        public void Critical(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Critical, message);
        }

        public void Fatal(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Fatal, message);
        }

        private void AppendToAppenders(string date, ReportLevel reportLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");
            foreach (Appender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
