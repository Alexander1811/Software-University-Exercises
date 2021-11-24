namespace ProductShop
{
    using AutoMapper;

    using DTO.Input;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputDto, User>();

            this.CreateMap<ProductInputDto, Product>();

            this.CreateMap<CategoryInputDto, Category>();

            this.CreateMap<CategoryProductInputDto, CategoryProduct>();
        }
    }
}
