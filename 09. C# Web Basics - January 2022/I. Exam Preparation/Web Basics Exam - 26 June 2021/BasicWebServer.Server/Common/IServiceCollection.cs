namespace BasicWebServer.Server.Common
{
    using System;

    public interface IServiceCollection
    {
        IServiceCollection Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService;

        IServiceCollection Add<TService>()
            where TService : class;

        TService Get<TService>()
            where TService : class;

        object CreateInstance(Type serviceType);
    }
}
