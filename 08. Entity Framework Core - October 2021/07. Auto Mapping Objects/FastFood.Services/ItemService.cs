namespace FastFood.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using DTO.Item;
    using Interfaces;
    using Models;

    public class ItemService : IItemService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreateItemDto dto)
        {
            var item = this.mapper.Map<Item>(dto);

            this.context.Items.Add(item);

            this.context.SaveChanges();
        }

        public ICollection<ListAllItemsDto> All()
        {
            return this.context.Items
                .ProjectTo<ListAllItemsDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}