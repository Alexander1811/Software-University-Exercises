namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Services.DTO.Position;
    using Services.Interfaces;
    using ViewModels.Positions;

    public class PositionsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPositionService positionService;

        public PositionsController(IMapper mapper, IPositionService positionService)
        {
            this.mapper = mapper;
            this.positionService = positionService;           
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            var positionDto = this.mapper.Map<CreatePositionDto>(model);

            this.positionService.Create(positionDto);

            return this.RedirectToAction("All", "Positions");
        }

        public IActionResult All()
        {
            var positionsDto = this.positionService.All();

            var positionViewModels = this.mapper
                .Map<ICollection<ListAllPositionsDto>, ICollection<PositionsAllViewModel>>(positionsDto)
                .ToList();

            return this.View("All", positionViewModels);
        }
    }
}
