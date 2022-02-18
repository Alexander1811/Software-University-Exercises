namespace CarDealer
{
    using AutoMapper;

    using DTO.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCarDto, Car>()
                .ForMember(x => x.PartCars, y => y.Ignore());

            this.CreateMap<ImportSaleDto, Sale>()
                .ForMember(x => x.Discount, y => y.MapFrom(s => (decimal) s.Discount / 100));

            this.CreateMap<ImportCustomerDto, Customer>();
        }
    }
}
