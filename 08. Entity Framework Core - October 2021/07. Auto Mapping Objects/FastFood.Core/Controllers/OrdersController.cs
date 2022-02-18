namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Services.DTO.Order;
    using Services.Interfaces;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService;
        private readonly IEmployeeService employeeService;
        private readonly IOrderService orderService;

        public OrdersController(IMapper mapper, IItemService itemService, IEmployeeService employeeService, IOrderService orderService)
        {
            this.mapper = mapper;
            this.itemService = itemService;
            this.employeeService = employeeService;
            this.orderService = orderService;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.itemService
                    .All()
                    .Select(i => new { i.Id, i.Name })
                    .ToDictionary(k => k.Id, v => v.Name),
                Employees = this.employeeService
                    .All()
                    .Select(i => new { i.Id, i.Name })
                    .ToDictionary(k => k.Id, v => v.Name)
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            model.ItemPrice = this.itemService.All().Where(i => i.Id == model.ItemId).SingleOrDefault().Price;

            var orderDto = this.mapper.Map<CreateOrderDto>(model);

            this.orderService.Create(orderDto);

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var ordersDto = this.orderService.All();

            var itemViewModels = this.mapper
                .Map<ICollection<ListAllOrdersDto>, ICollection<OrdersAllViewModel>>(ordersDto)
                .ToList();

            return this.View("All", itemViewModels);
        }
    }
}