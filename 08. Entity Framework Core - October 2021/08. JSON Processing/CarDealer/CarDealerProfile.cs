namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DTO.Input;
    using Models;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierInputDto, Supplier>();

            this.CreateMap<PartInputDto, Part>();

            this.CreateMap<CarInputDto, Car>()
                .ForMember(x => x.PartCars, y => y.Ignore()); //Done manually because of the mapping table.

            this.CreateMap<SaleInputDto, Sale>()
                .ForMember(x => x.Discount, y => y.MapFrom(s => (decimal) s.Discount / 100));

            this.CreateMap<CustomerInputDto, Customer>();
        }
    }
}
