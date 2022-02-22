namespace SMS.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Contracts;
    using SMS.Data.Common;

    public class CartsController : Controller
    {
        private readonly IRepository repository;
        private readonly ICartService cartService;

        public CartsController(Request request,
            IRepository repository,
            ICartService cartService)
            : base(request)
        {
            this.repository = repository;
            this.cartService = cartService;
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            var products = this.cartService.AddProduct(productId, this.User.Id);

            return View(new
            {
                Products = products,
                IsAuthenticated = true
            }, "/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            this.cartService.Buy(this.User.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Details()
        {
            var products = this.cartService.GetProducts(User.Id);

            return View(new
            {
                Products = products,
                IsAuthenticated = true
            });
        }
    }
}