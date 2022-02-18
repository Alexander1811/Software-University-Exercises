namespace BasicWebServer.Server.Attributes
{
    using BasicWebServer.Server.HTTP;

    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute() : base(Method.Get)
        {
        }
    }
}
