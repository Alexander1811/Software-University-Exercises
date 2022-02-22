namespace SMS.Services
{
    using AutoMapper;
    using SMS.Common;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly IRepository repository;
        private readonly IValidationService validationService;

        private readonly IMapper mapper;

        public ProductService(
            IRepository repository,
            IValidationService validationService,
            IMappingService mappingService)
        {
            this.repository = repository;
            this.validationService = validationService;

            this.mapper = mappingService.CreateMapper();
        }

        public IEnumerable<ProductListViewModel> All()
        {
            var products = this.repository.All<Product>();

            var models = this.mapper
                .ProjectTo<ProductListViewModel>(products)
                .ToList();

            return models;
        }

        public (bool isValid, string errors) ValidateModel(ProductCreateViewModel model)
        {
            var (isValid, errors) = this.validationService.ValidateModel(model);

            if (!int.TryParse(model.Price, out _))
            {
                isValid = false;
                errors += Environment.NewLine + ErrorMessages.ProductInvalidPrice;
            }

            return (isValid, errors);
        }

        public void Create(ProductCreateViewModel model)
        {
            var product = this.mapper.Map<Product>(model);

            this.repository.Add(product);
            this.repository.SaveChanges();
        }
    }
}
