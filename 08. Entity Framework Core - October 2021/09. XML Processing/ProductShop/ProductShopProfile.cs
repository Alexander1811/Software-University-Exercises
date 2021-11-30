namespace ProductShop
{
    using System.Linq;
    
    using AutoMapper;

    using DTO.Export;
    using DTO.Import;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();

            this.CreateMap<ImportProductDto, Product>();

            this.CreateMap<ImportCategoryDto, Category>();

            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(x => x.Buyer, y => y.MapFrom(s => s.Buyer.FirstName + " " + s.Buyer.LastName));

            this.CreateMap<Product, ExportSoldProductDto>();
            this.CreateMap<User, ExportSoldProductsByUserDto>();

            this.CreateMap<Category, ExportCategoryByProductsCountDto>()
                .ForMember(x => x.Count, y => y.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(s => s.CategoryProducts.Sum(cp => cp.Product.Price)));

            //this.CreateMap<User, ExportUserWithProductsDto>();
        }
    }
}
