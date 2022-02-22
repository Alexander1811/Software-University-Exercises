namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Contracts;
    using FootballManager.ViewModels.Players;
    using System;

    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(Request request, IPlayerService playerService)
            : base(request)
        {
            this.playerService = playerService;
        }

        [Authorize]
        public Response All()
        {
            return View(new { this.User.IsAuthenticated });
        }

        [Authorize]
        public Response Collection()
        {
            var model = new
            {
                IsAuthenticated = true,
                Players = this.playerService.Collection(this.User.Id)
            };

            return View(model, "/Players/Collection");
        }

        [Authorize]
        public Response Add()
        {
            return View(new { this.User.IsAuthenticated });
        }

        [Authorize]
        public Response AddToCollection(string playerId)
        {
            try
            {
                this.playerService.AddToCollection(int.Parse(playerId), this.User.Id);
            }
            catch (Exception)
            {
                return Redirect("/");
            }

            return Redirect("/");
        }

        [Authorize]
        public Response RemoveFromCollection(string playerId)
        {
            try
            {
                this.playerService.RemoveFromCollection(int.Parse(playerId), this.User.Id);
            }
            catch (Exception)
            {
                return Redirect("/");
            }

            var model = new
            {
                IsAuthenticated = true,
                Players = this.playerService.Collection(this.User.Id)
            };

            return View(model, "/Players/Collection");
        }

        [Authorize]
        [HttpPost]
        public Response Add(PlayerAddViewModel model)
        {
            var isValid = this.playerService.ValidateModel(model);

            if (!isValid)
            {
                return Redirect("/");
            }

            try
            {
                this.playerService.Add(model);
            }
            catch (Exception)
            {
                return Redirect("/Players/Add");
            }

            return Redirect("/");
        }
    }
}
