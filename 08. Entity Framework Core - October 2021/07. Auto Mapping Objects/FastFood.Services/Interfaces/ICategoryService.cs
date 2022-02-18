namespace FastFood.Services.Interfaces
{
    using System.Collections.Generic;

    using DTO.Category;

    public interface ICategoryService
    {
        void Create(CreateCategoryDto dto);

        ICollection<ListAllCategoriesDto> All();

        ICollection<ItemCreateCategoriesAvailable> GetCategoriesAvailable();
    }
}
