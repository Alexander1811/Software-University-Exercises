using _01._Logger.Appenders;
using _01._Logger.Enums;
using _01._Logger.Layouts;

namespace _01._Logger.Core.Factories
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel);
    }
}
