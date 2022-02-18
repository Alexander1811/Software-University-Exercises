namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Services.DTO.Category;
    using Services.DTO.Item;
    using Services.Interfaces;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        private readonly IItemService itemService;

        public ItemsController(IMapper mapper, ICategoryService categoryService, IItemService itemService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        public IActionResult Create()
        {
            var categoriesDto = this.categoryService.GetCategoriesAvailable();

            var createItemViewModel = this.mapper
                .Map<ICollection<ItemCreateCategoriesAvailable>, ICollection<CreateItemViewModel>>(categoriesDto)
                .ToList();

            return this.View(createItemViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            var itemDto = this.mapper.Map<CreateItemDto>(model);

            this.itemService.Create(itemDto);

            return this.RedirectToAction("All", "Items");
        }

        public IActionResult All()
        {
            var itemsDto = this.itemService.All();

            var itemViewModels = this.mapper
                .Map<ICollection<ListAllItemsDto>, ICollection<ItemsAllViewModel>>(itemsDto)
                .ToList();

            return this.View("All", itemViewModels);
        }
    }
}