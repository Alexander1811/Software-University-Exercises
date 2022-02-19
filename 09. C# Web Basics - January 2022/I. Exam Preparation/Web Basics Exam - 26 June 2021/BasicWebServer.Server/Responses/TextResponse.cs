namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;

    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, ContentType.PlainText)
        {
        }
    }
}
