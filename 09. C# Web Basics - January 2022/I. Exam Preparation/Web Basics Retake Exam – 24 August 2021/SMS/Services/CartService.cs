namespace SMS.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models.Carts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CartService : ICartService
    {
        private readonly IRepository repository;

        private readonly IMapper mapper;

        public CartService(
            IRepository repository,
            IMappingService mappingService)
        {
            this.repository = repository;

            this.mapper = mappingService.CreateMapper();
        }

        public IEnumerable<CartViewModel> AddProduct(string productId, string userId)
        {
            var user = repository.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            var product = repository.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            user.Cart.Products.Add(product);

            var products = user.Cart.Products;

            try
            {
                repository.SaveChanges();
            }
            catch (Exception) { }

            var models = this.mapper
                .ProjectTo<CartViewModel>(products.AsQueryable())
                .ToList();

            return models;
        }

        public void Buy(string userId)
        {
            var user = this.repository.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            user.Cart.Products.Clear();

            this.repository.SaveChanges();
        }

        public IEnumerable<CartViewModel> GetProducts(string userId)
        {
            var products = repository.All<User>()
                   .Where(u => u.Id == userId)
                   .Include(u => u.Cart)
                   .ThenInclude(c => c.Products)
                   .FirstOrDefault()
                   .Cart.Products.AsQueryable();

            var models = this.mapper
                .ProjectTo<CartViewModel>(products.AsQueryable())
                .ToList();

            return models;
        }
    }
}
