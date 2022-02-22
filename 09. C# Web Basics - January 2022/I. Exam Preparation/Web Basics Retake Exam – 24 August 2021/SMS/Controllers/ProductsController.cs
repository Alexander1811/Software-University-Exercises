namespace SharedProduct.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Common;
    using SMS.Contracts;
    using SMS.Models.Products;
    using System;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(Request request, IProductService productService)
            : base(request)
        {
            this.productService = productService;
        }

        [Authorize]
        public Response Create()
        {
            return View(new { this.User.IsAuthenticated });
        }

        [Authorize]
        [HttpPost]
        public Response Create(ProductCreateViewModel model)
        {
            var (isValid, errors) = this.productService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                this.productService.Create(model);
            }
            catch (ArgumentException aex)
            {
                errors += Environment.NewLine + aex.Message;
                return View(new { ErrorMessage = errors }, "/Error");
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = ErrorMessages.UnexpectedError }, "/Error");
            }

            return Redirect("/");
        }
    }
}
