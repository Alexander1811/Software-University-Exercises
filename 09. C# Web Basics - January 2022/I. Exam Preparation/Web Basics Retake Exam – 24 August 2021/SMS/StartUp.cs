namespace SMS
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SMS.Contracts;
    using SMS.Data;
    using SMS.Data.Common;
    using SMS.Services;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
               .Add<IValidationService, ValidationService>()
               .Add<IMappingService, MappingService>()
               .Add<IHashingService, HashingService>()
               .Add<IRepository, Repository>()
               .Add<IUserService, UserService>()
               .Add<IProductService, ProductService>()
               .Add<ICartService, CartService>()
               .Add<SMSDbContext>();

            await server.Start();
        }
    }
}