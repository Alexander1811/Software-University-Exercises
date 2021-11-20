namespace FastFood.Services.Interfaces
{
    using System.Collections.Generic;

    using DTO.Item;

    public interface IItemService
    {
        void Create(CreateItemDto dto);

        ICollection<ListAllItemsDto> All();
    }
}
