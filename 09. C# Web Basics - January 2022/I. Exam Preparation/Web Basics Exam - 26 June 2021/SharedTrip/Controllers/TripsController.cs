namespace SharedTrip.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Common;
    using SharedTrip.Contracts;
    using SharedTrip.Models;
    using SharedTrip.Models.Trips;
    using System;
    using System.Collections.Generic;

    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(Request request, ITripService tripService)
            : base(request)
        {
            this.tripService = tripService;
        }

        [Authorize]
        public Response All()
        {
            var models = this.tripService.All();

            return View(models);
        }

        [Authorize]
        public Response Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public Response Add(TripAddViewModel model)
        {
            var (isValid, errors) = this.tripService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                this.tripService.Add(model);
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

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response Details(string tripId)
        {
            var model = this.tripService.Details(tripId);

            return View(model);
        }

        [Authorize]
        public Response AddUserToTrip(string tripId)
        {
            var errors = new List<ErrorViewModel>();

            try
            {
                this.tripService.AddUserToTrip(tripId, this.User.Id);
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

            return Redirect("/Trips/All");
        }

    }
}
