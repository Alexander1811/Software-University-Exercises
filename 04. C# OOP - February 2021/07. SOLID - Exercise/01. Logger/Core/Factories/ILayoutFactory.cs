using _01._Logger.Layouts;

namespace _01._Logger.Core.Factories
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
