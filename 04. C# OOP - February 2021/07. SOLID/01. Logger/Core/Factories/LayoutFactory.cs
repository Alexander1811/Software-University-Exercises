namespace P01_Logger.Core.Factories
{
    using P01_Logger.Layouts;

    public class LayoutFactory : ILayoutFactory
    {
        ILayout ILayoutFactory.CreateLayout(string type)
        {
            ILayout layout = null;

            if (type == nameof(SimpleLayout))
            {
                layout = new SimpleLayout();
            }
            else if (type == nameof(XmlLayout))
            {
                layout = new XmlLayout();
            }
            else if (type == nameof(JsonLayout))
            {
                layout = new JsonLayout();
            }
            else
            {
                Validator.ThrowInvalidLayoutTypeException(type);
            }

            return layout;
        }
    }
}
