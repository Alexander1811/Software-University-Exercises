namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;
    using System.IO;
    using System.Linq;

    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controllerName, object model = null)
            : base("", ContentType.Html)
        {
            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath(
                $"./Views/"
                + viewName.TrimStart(PathSeparator)
                + ".cshtml");

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = PopulateModel(viewContent, model);
            }

            this.Body = viewContent;
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(prop => new
                {
                    prop.Name,
                    Value = prop.GetValue(model)
                });

            foreach (var entry in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent.Replace(
                    $"{openingBrackets}{entry.Name}{closingBrackets}",
                    entry.Value.ToString());
            }

            return viewContent;
        }
    }
}
