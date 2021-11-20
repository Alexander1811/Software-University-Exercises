namespace FastFood.Core.MappingConfiguration
{
    using System;

    using AutoMapper;
    
    using FastFood.Models;
    using Services.DTO.Category;
    using Services.DTO.Employee;
    using Services.DTO.Item;
    using Services.DTO.Order;
    using Services.DTO.Position;
    using ViewModels.Categories;
    using ViewModels.Employees;
    using ViewModels.Items;
    using ViewModels.Orders;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
                //Create position in database
            this.CreateMap<CreatePositionInputModel, CreatePositionDto>();

            this.CreateMap<CreatePositionDto, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            //Get all positions from database
            this.CreateMap<Position, ListAllPositionsDto>();

            this.CreateMap<ListAllPositionsDto, PositionsAllViewModel>();

            //Available employee positions
            this.CreateMap<Position, EmployeeRegisterPositionsAvailable>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            this.CreateMap<EmployeeRegisterPositionsAvailable, RegisterEmployeeViewModel>();

            //Employees
                //Register employee in database
            this.CreateMap<RegisterEmployeeInputModel, RegisterEmployeeDto>();

            this.CreateMap<RegisterEmployeeDto, Employee>();

                //Get all employees from database
            this.CreateMap<Employee, ListAllEmployeesDto>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));

            this.CreateMap<ListAllEmployeesDto, EmployeesAllViewModel>();

            //Categories
                //Create category in database
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>();

            this.CreateMap<CreateCategoryDto, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

                //Get all categories from database
            this.CreateMap<Category, ListAllCategoriesDto>();

            this.CreateMap<ListAllCategoriesDto, CategoriesAllViewModel>();

            //Available item categories
            this.CreateMap<Category, ItemCreateCategoriesAvailable>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            this.CreateMap<ItemCreateCategoriesAvailable, CreateItemViewModel>();

            //Items
                //Create item in database
            this.CreateMap<CreateItemInputModel, CreateItemDto>();

            this.CreateMap<CreateItemDto, Item>();

                //Get all items from database
            this.CreateMap<Item, ListAllItemsDto>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            this.CreateMap<ListAllItemsDto, ItemsAllViewModel>();

            //Orders
                //Create order in database
            this.CreateMap<CreateOrderInputModel, CreateOrderDto>();

            this.CreateMap<CreateOrderDto, Order>()
                .ForMember(x => x.DateTime, y => y.MapFrom(s => DateTime.Now))
                .ForMember(x => x.TotalPrice, y => y.MapFrom(s => s.ItemPrice * s.Quantity));

                //Get all orders from database
            this.CreateMap<Order, ListAllOrdersDto>()
                .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("dd.MM.yyyy mm:HH")));

            this.CreateMap<ListAllOrdersDto, OrdersAllViewModel>();
        }
    }
}
