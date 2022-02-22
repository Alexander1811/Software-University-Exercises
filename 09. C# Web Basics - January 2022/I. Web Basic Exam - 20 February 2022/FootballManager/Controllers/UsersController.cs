namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Contracts;
    using FootballManager.ViewModels.Users;
    using System;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService userService)
            : base(request)
        {
            this.userService = userService;
        }

        public Response Register()
        {
            var model = new { this.User.IsAuthenticated };

            if (this.User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(model);
        }

        public Response Login()
        {
            var model = new { this.User.IsAuthenticated };

            if (this.User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(model);
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var isValid = this.userService.ValidateModel(model);

            if (!isValid)
            {
                return Redirect("/Users/Register");
            }

            try
            {
                this.userService.RegisterUser(model);
            }
            catch (Exception)
            {
                return Redirect("/Users/Register");
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            this.Request.Session.Clear();

            (string userId, bool isCorrect) = this.userService.IsLoginCorrect(model);

            if (!isCorrect)
            {
                return Redirect("/Users/Login");
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, this.Request.Session.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
