using _01._Logger.Appenders;
using _01._Logger.Enums;
using _01._Logger.Layouts;
using _01._Logger.Loggers;

namespace _01._Logger.Core.Factories
{
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
