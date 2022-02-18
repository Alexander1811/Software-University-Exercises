namespace BasicWebServer.Server.Controllers
{
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Responses;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Controller(Request request)
        {
            this.Request = request;
        }

        protected Request Request { get; private init; }

        protected Response Text(string text) => new TextResponse(text);

        protected Response Html(string html, CookieCollection cookies = null)
        {
            var response = new HtmlResponse(html);

            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }

            return response;
        }

        protected Response BadRequest() => new BadRequestResponse();

        protected Response Unauthorized() => new UnauthorizedResponse();

        protected Response NotFound() => new NotFoundResponse();

        protected Response Redirect(string location) => new RedirectResponse(location);

        protected Response File(string fileName) => new TextFileResponse(fileName);

        protected Response View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, ControllerGetName());

        protected Response View(object model, [CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, ControllerGetName(), model);

        private string ControllerGetName()
            => GetType().Name
                .Replace(nameof(Controller), string.Empty);
    }
}
