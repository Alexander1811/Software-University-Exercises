namespace FastFood.Services.Interfaces
{
    using System.Collections.Generic;

    using DTO.Employee;

    public interface IEmployeeService
    {
        void Register(RegisterEmployeeDto dto);

        ICollection<ListAllEmployeesDto> All();
    }
}
