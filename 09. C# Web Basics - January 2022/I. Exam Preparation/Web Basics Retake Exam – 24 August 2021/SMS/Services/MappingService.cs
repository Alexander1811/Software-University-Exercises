namespace SMS.Services
{
    using AutoMapper;
    using SMS.Contracts;
    using SMS.MappingConfiguration;

    public class MappingService : IMappingService
    {
        public IMapper CreateMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SMSProfile>();
            }));
    }
}
