namespace FastFood.Services.Interfaces
{
    using System.Collections.Generic;

    using DTO.Position;

    public interface IPositionService
    {
        void Create(CreatePositionDto dto);

        ICollection<ListAllPositionsDto> All();

        ICollection<EmployeeRegisterPositionsAvailable> GetPositionsAvailables();
    }
}
