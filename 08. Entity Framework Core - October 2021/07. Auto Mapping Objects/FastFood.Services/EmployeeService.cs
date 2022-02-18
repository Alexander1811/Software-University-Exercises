namespace FastFood.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    
    using Data;
    using DTO.Employee;
    using Interfaces;
    using Models;

    public class EmployeeService : IEmployeeService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeeService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Register(RegisterEmployeeDto dto)
        {
            var employee = this.mapper.Map<Employee>(dto);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public ICollection<ListAllEmployeesDto> All()
        {
            return this.context.Employees
                .ProjectTo<ListAllEmployeesDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
