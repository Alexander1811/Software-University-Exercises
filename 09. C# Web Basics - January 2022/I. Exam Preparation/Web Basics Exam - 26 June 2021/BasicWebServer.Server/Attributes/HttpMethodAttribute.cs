namespace BasicWebServer.Server.Attributes
{
    using BasicWebServer.Server.HTTP;
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {
        public Method HttpMethod { get; }

        protected HttpMethodAttribute(Method httpMethod)
            => HttpMethod = httpMethod;
    }
}
