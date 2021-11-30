namespace CarDealer
{
    using System;
    using System.Linq;

    using AutoMapper;
    
    using DTO.Export;
    using DTO.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>()
                .ForMember(x => x.IsImporter, y => y.MapFrom(s => bool.Parse(s.IsImporter)));

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCarDto, Car>()
                .ForMember(x => x.PartCars, y => y.Ignore());

            this.CreateMap<ImportCustomerDto, Customer>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(s => DateTime.Parse(s.BirthDate)))
                .ForMember(x => x.IsYoungDriver, y => y.MapFrom(s => bool.Parse(s.IsYoungDriver)));

            this.CreateMap<ImportSaleDto, Sale>()
                .ForMember(x => x.Discount, y => y.MapFrom(s => s.Discount / 100));

            this.CreateMap<Car, ExportCarWithDistanceDto>();

            this.CreateMap<Car, ExportCarFromMakeBmwDto>();

            this.CreateMap<Supplier, ExportLocalSupplierDto>()
                .ForMember(x => x.PartsCount, y => y.MapFrom(s => s.Parts.Count));

            this.CreateMap<PartCar, ExportPartCarDto>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Part.Name))
                .ForMember(x => x.Price, y => y.MapFrom(s => s.Part.Price));
            this.CreateMap<Car, ExportCarWithTheirListOfPartsDto>()
                .ForMember(x => x.Parts, y => y.MapFrom(s => s.PartCars.OrderByDescending(pc => pc.Part.Price)));

            this.CreateMap<Customer, ExportTotalSalesByCustomerDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(s => s.Sales.Count))
                .ForMember(x => x.SpentMoney, y => y.MapFrom(s => s.Sales.Sum(c => c.Car.PartCars.Sum(p => p.Part.Price))));

            this.CreateMap<Car, ExportCarSaleDto>();
            this.CreateMap<Sale, ExportSaleWithAppliedDiscountDto>()
                .ForMember(x => x.Discount, y => y.MapFrom(s => (s.Discount * 100)))
                .ForMember(x => x.CustomerName, y => y.MapFrom(s => s.Customer.Name))
                .ForMember(x => x.Price, y => y.MapFrom(s => s.Car.PartCars.Sum(p => p.Part.Price)))
                .ForMember(x => x.PriceWithDiscount, y => y.MapFrom(s => s.Car.PartCars.Sum(c => c.Part.Price) - (s.Car.PartCars.Sum(y => y.Part.Price) * s.Discount)));
        }
    }
}
