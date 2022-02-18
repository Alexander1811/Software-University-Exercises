namespace FastFood.Services.Interfaces
{
    using System.Collections.Generic;

    using DTO.Order;

    public interface IOrderService
    {
        void Create(CreateOrderDto dto);

        ICollection<ListAllOrdersDto> All();
    }
}
