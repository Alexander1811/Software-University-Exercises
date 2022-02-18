namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;

    public class BadRequestResponse : Response
    {
        public BadRequestResponse()
             : base(StatusCode.BadRequest)
        {
        }
    }
}
