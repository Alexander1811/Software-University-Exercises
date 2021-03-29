using _01._Logger.Enums;

namespace _01._Logger.Appenders
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(string date, ReportLevel reportLevel, string message);
    }
}
