namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Services.DTO.Category;
    using Services.Interfaces;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            var categoryDto = this.mapper.Map<CreateCategoryDto>(model);

            this.categoryService.Create(categoryDto);

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var categoriesDto = this.categoryService.All();

            var categoryViewModels = this.mapper
                .Map<ICollection<ListAllCategoriesDto>, ICollection<CategoriesAllViewModel>>(categoriesDto)
                .ToList();

            return this.View("All", categoryViewModels);
        }
    }
}
