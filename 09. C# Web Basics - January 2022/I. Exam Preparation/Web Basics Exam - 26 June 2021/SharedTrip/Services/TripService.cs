namespace SharedTrip.Services
{
    using AutoMapper;
    using SharedTrip.Common;
    using SharedTrip.Contracts;
    using SharedTrip.Data.Common;
    using SharedTrip.Data.Models;
    using SharedTrip.Models;
    using SharedTrip.Models.Trips;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TripService : ITripService
    {
        private readonly IRepository repository;
        private readonly IValidationService validationService;

        private readonly IMapper mapper;

        public TripService(
            IRepository repository,
            IValidationService validationService,
            IMappingService mappingService)
        {
            this.repository = repository;
            this.validationService = validationService;

            this.mapper = mappingService.CreateMapper();
        }

        public IEnumerable<TripListViewModel> All()
        {
            var trips = this.repository.All<Trip>();

            var models = this.mapper
                .ProjectTo<TripListViewModel>(trips)
                .ToList();

            return models;
        }

        public (bool isValid, List<ErrorViewModel> errors) ValidateModel(TripAddViewModel model)
        {
            var (isValid, errors) = this.validationService.ValidateModel(model);

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                isValid = false;
                errors.Add(new ErrorViewModel(ErrorMessages.TripInvalidDepartureTime));
            }
            if (!int.TryParse(model.Seats, out _))
            {
                isValid = false;
                errors.Add(new ErrorViewModel(ErrorMessages.TripInvalidSeats));
            }

            return (isValid, errors);
        }

        public void Add(TripAddViewModel model)
        {
            var trip = this.mapper.Map<Trip>(model);

            this.repository.Add(trip);
            this.repository.SaveChanges();
        }

        public TripDetailsViewModel Details(string tripId)
        {
            var trip = this.repository.All<Trip>()
                .FirstOrDefault(t => t.Id == tripId);
            var model = this.mapper.Map<TripDetailsViewModel>(trip);

            return model;
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var user = this.repository.All<User>()
                .FirstOrDefault(u => u.Id == userId);
            var trip = this.repository.All<Trip>()
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException(ErrorMessages.UserTripPairInvalid);
            }

            var seatsAvailable = trip.Seats;
            var seatsTaken = this.repository.All<UserTrip>().Where(ut => ut.TripId == tripId).Count();

            if (seatsAvailable - seatsTaken == 0)
            {
                throw new ArgumentException(ErrorMessages.TripNoFreeSeats);
            }

            this.repository.Add<UserTrip>(new UserTrip
            {
                TripId = tripId,
                Trip = trip,
                UserId = userId,
                User = user
            });

            this.repository.SaveChanges();
        }
    }
}
