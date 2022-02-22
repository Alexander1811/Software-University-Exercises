namespace SMS.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Contracts;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProductService productService;

        public HomeController(Request request,
            IUserService userService,
            IProductService productService)
            : base(request)
        {
            this.userService = userService;
            this.productService = productService;
        }

        public Response Index()
        {
            if (this.User.IsAuthenticated)
            {
                string username = this.userService.GetUsername(this.User.Id);

                var model = new
                {
                    Username = username,
                    IsAuthenticated = true,
                    Products = this.productService.All()
                };

                return View(model, "/Home/IndexLoggedIn");
            }

            return View(new { this.User.IsAuthenticated });
        }
    }
}