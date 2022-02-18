namespace SharedTrip.MappingConfiguration
{
    using AutoMapper;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using System.Globalization;

    public class SharedTripProfile : Profile
    {
        public SharedTripProfile()
        {
            //Users
            CreateMap<RegisterViewModel, User>()
                .ForMember(x => x.Password, y => y.Ignore());
            CreateMap<LoginViewModel, User>();

            //Trips
            CreateMap<Trip, TripListViewModel>()
                .ForMember(x => x.DepartureTime, y => y.MapFrom(s => s.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(x => x.Seats, y => y.MapFrom(s => (s.Seats - s.UserTrips.Count).ToString()));
            CreateMap<TripAddViewModel, Trip>();
            CreateMap<Trip, TripDetailsViewModel>();
        }
    }
}
