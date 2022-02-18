namespace P01_Logger.Appenders
{
    using P01_Logger.Enums;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(string date, ReportLevel reportLevel, string message);
    }
}
