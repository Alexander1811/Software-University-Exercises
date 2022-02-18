namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html)
            : base(html, ContentType.Html)
        {
        }
    }
}
