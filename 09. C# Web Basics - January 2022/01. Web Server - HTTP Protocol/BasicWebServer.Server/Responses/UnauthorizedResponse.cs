namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;

    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
