namespace BasicWebServer.Server.Attributes
{
    using BasicWebServer.Server.HTTP;

    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute() : base(Method.Post)
        {
        }
    }
}
