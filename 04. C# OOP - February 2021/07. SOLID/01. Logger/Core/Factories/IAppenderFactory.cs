namespace P01_Logger.Core.Factories
{
    using P01_Logger.Appenders;
    using P01_Logger.Enums;
    using P01_Logger.Layouts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel);
    }
}
