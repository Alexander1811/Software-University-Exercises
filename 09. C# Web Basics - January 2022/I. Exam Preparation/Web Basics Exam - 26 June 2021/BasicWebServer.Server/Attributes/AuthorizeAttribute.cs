namespace BasicWebServer.Server.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute
    {
    }
}
