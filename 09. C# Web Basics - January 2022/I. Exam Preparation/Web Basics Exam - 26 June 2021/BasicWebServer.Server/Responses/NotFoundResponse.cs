namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;

    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
             : base(StatusCode.NotFound)
        {
        }
    }
}
