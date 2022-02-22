namespace SMS.Contracts
{
    using SMS.Models.Products;
    using System.Collections.Generic;

    public interface IProductService
    {
        (bool isValid, string errors) ValidateModel(ProductCreateViewModel model);

        void Create(ProductCreateViewModel model);

        IEnumerable<ProductListViewModel> All();
    }
}
