namespace SharedTrip.Services
{
    using AutoMapper;
    using SharedTrip.Contracts;
    using SharedTrip.MappingConfiguration;

    public class MappingService : IMappingService
    {
        public IMapper CreateMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SharedTripProfile>();
            }));
    }
}
