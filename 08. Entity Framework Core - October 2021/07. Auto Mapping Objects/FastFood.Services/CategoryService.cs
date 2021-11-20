namespace FastFood.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using DTO.Category;
    using Interfaces;
    using Models;

    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreateCategoryDto dto)
        {
            var category = this.mapper.Map<Category>(dto);

            this.context.Categories.Add(category);

            this.context.SaveChanges();
        }

        public ICollection<ListAllCategoriesDto> All()
        {
            return this.context
                .Categories
                .ProjectTo<ListAllCategoriesDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public ICollection<ItemCreateCategoriesAvailable> GetCategoriesAvailable()
        {
            return this.context
                .Categories
                .ProjectTo<ItemCreateCategoriesAvailable>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
