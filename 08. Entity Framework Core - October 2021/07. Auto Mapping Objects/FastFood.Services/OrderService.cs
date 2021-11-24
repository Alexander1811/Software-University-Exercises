namespace FastFood.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using DTO.Order;
    using Interfaces;
    using Models;

    public class OrderService : IOrderService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrderService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreateOrderDto dto)
        {
            var order = this.mapper.Map<Order>(dto);

            this.context.Orders.Add(order);

            this.context.SaveChanges();
        }

        public ICollection<ListAllOrdersDto> All()
        {
            return this.context.Orders
                .ProjectTo<ListAllOrdersDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}