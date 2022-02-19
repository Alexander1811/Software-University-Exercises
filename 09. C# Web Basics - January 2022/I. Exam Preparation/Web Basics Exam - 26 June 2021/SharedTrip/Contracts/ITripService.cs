namespace SharedTrip.Contracts
{
    using SharedTrip.Models;
    using SharedTrip.Models.Trips;
    using System.Collections.Generic;

    public interface ITripService
    {
        (bool isValid, List<ErrorViewModel> errors) ValidateModel(TripAddViewModel model);

        void Add(TripAddViewModel model);

        IEnumerable<TripListViewModel> All();

        TripDetailsViewModel Details(string tripId);

        void AddUserToTrip(string tripId, string id);
    }
}
