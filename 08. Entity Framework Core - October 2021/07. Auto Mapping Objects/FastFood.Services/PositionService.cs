namespace FastFood.Services
{
    using System.Collections.Generic;
    using System.Linq;
    
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    
    using Data;
    using DTO.Position;
    using Interfaces;
    using Models;

    public class PositionService : IPositionService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public PositionService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreatePositionDto dto)
        {
            var position = this.mapper.Map<Position>(dto);

            this.context.Positions.Add(position);

            this.context.SaveChanges();
        }

        public ICollection<ListAllPositionsDto> All()
        {
            return this.context
                .Positions
                .ProjectTo<ListAllPositionsDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public ICollection<EmployeeRegisterPositionsAvailable> GetPositionsAvailables()
        {
            return this.context
                .Positions
                .ProjectTo<EmployeeRegisterPositionsAvailable>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
