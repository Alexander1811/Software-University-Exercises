namespace SMS.MappingConfiguration
{
    using AutoMapper;
    using SMS.Data.Models;
    using SMS.Models.Carts;
    using SMS.Models.Products;
    using SMS.Models.Users;

    public class SMSProfile : Profile
    {
        public SMSProfile()
        {
            //Users
            CreateMap<RegisterViewModel, User>()
                .ForMember(x => x.Password, y => y.Ignore());
            CreateMap<LoginViewModel, User>();

            //Products
            CreateMap<Product, ProductListViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.ProductName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.ProductPrice, y => y.MapFrom(s => s.Price.ToString("f2")));
            CreateMap<ProductCreateViewModel, Product>()
                .ForMember(x => x.Price, y => y.MapFrom(s => decimal.Parse(s.Price)));
            CreateMap<Product, CartViewModel>()
                .ForMember(x => x.ProductName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.ProductPrice, y => y.MapFrom(s => s.Price.ToString("f2")));
        }
    }
}
