namespace FootballManager.Services
{
    using AutoMapper;
    using FootballManager.Contracts;
    using FootballManager.MappingConfiguration;

    public class MappingService : IMappingService
    {
        public IMapper CreateMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballManagerProfile>();
            }));
    }
}
