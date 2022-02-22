namespace SMS.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SMS.Common;
    using SMS.Contracts;
    using SMS.Models.Users;
    using System;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService userService)
            : base(request)
        {
            this.userService = userService;
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

        public Response Register()
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
            var (isValid, errors) = this.userService.ValidateModel(model);

            if (!isValid)
            {
                return View(new { ErrorMessage = errors }, "/Error");
            }

            try
            {
                this.userService.RegisterUser(model);
            }
            catch (ArgumentException aex)
            {
                errors += Environment.NewLine + aex.Message;
                return View(new { ErrorMessage = errors }, "/Error");
            }
            catch (Exception)
            {
                errors += Environment.NewLine + ErrorMessages.UnexpectedError;
                return View(new { ErrorMessage = errors }, "/Error");
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
                return View(new { ErrorMessage = ErrorMessages.LoginFailed }, "/Error");
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
