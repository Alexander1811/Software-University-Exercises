namespace P01_Logger.Core.Factories
{
    using P01_Logger.Layouts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
