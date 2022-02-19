namespace BasicWebServer.Server.Routing
{
    using BasicWebServer.Server.HTTP;
    using System;

    public interface IRoutingTable
    {
        IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction);
    }
}
