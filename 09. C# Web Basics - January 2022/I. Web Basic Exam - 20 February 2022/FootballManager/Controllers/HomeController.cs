namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Contracts;

    public class HomeController : Controller
    {
        private readonly IPlayerService playerService;

        public HomeController(Request request, IPlayerService playerService)
            : base(request)
        {
            this.playerService = playerService;
        }

        public Response Index()
        {
            if (this.User.IsAuthenticated)
            {
                var model = new
                {
                    IsAuthenticated = true,
                    Players = this.playerService.All()
                };

                return View(model, "/Players/All");
            }

            return View(new { this.User.IsAuthenticated });
        }
    }
}
