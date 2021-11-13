namespace P01_Logger.Core.Factories
{
    using P01_Logger.Appenders;
    using P01_Logger.Enums;
    using P01_Logger.Layouts;
    using P01_Logger.Loggers;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender = null;

            if (type == nameof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout)
                {
                    ReportLevel = reportLevel
                };
            }
            else if (type == nameof(FileAppender))
            {
                appender = new FileAppender(layout, new LogFile())
                {
                    ReportLevel = reportLevel
                };
            }
            else
            {
                Validator.ThrowInvalidAppenderTypeException(type);
            }

            return appender;
        }
    }
}
