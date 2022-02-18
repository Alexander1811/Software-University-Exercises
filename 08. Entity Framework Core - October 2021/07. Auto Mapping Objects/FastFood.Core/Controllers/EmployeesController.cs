namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Services.DTO.Employee;
    using Services.DTO.Position;
    using Services.Interfaces;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPositionService positionService;
        private readonly IEmployeeService employeeService;

        public EmployeesController(IMapper mapper, IPositionService positionService, IEmployeeService employeeService)
        {
            this.mapper = mapper;
            this.positionService = positionService;
            this.employeeService = employeeService;
        }

        public IActionResult Register()
        {
            var positionsDto = this.positionService.GetPositionsAvailables();

            var registerEmployeeViewModel = this.mapper
                .Map<ICollection<EmployeeRegisterPositionsAvailable>, ICollection<RegisterEmployeeViewModel>>(positionsDto)
                .ToList();

            return this.View(registerEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register");
            }

            var employeeDto = this.mapper.Map<RegisterEmployeeDto>(model);

            this.employeeService.Register(employeeDto);

            return this.RedirectToAction("All", "Employees");
        }

        public IActionResult All()
        {
            var employeesDto = this.employeeService.All();

            var employeeViewModels = this.mapper
                .Map<ICollection<ListAllEmployeesDto>, ICollection<EmployeesAllViewModel>>(employeesDto)
                .ToList();

            return this.View("All", employeeViewModels);
        }
    }
}
