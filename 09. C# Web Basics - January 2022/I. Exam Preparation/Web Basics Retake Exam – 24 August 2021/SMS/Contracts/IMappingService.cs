namespace SMS.Contracts
{
    using AutoMapper;

    public interface IMappingService
    {
        IMapper CreateMapper();
    }
}
