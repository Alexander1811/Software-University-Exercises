namespace SharedTrip.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Common;
    using SharedTrip.Contracts;
    using SharedTrip.Models;
    using SharedTrip.Models.Users;
    using System;
    using System.Collections.Generic;

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
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return View();
        }

        public Response Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return View();
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isValid, errors) = this.userService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                this.userService.RegisterUser(model);
            }
            catch (ArgumentException aex)
            {
                errors.Add(new ErrorViewModel(aex.Message));
                return View(errors, "/Error");
            }
            catch (Exception)
            {
                errors.Add(new ErrorViewModel(ErrorMessages.UnexpectedError));
                return View(errors, "/Error");
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            this.Request.Session.Clear();

            (string userId, bool isCorrect) = this.userService.IsLoginCorrect(model);

            if (isCorrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName,
                    this.Request.Session.Id);

                return Redirect("/Trips/All");
            }

            return View(new List<ErrorViewModel>() { new ErrorViewModel(ErrorMessages.LoginInvalid) }, "/Error");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
