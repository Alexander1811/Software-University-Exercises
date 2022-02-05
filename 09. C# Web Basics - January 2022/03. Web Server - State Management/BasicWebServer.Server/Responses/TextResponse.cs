namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;
    using System;

    public class TextResponse : ContentResponse
    {
        public TextResponse(string text,
            Action<Request, Response> preRenderAction = null)
            : base(text, ContentType.PlainText, preRenderAction)
        {
        }
    }
}
