namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using AutoMapper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Data;
    using DTO.Import;
    using Models;

    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string usersJsonString =
                File.ReadAllText("../../../Datasets/users.json");
            string productsJsonString =
                File.ReadAllText("../../../Datasets/products.json");
            string categoriesJsonString =
                File.ReadAllText("../../../Datasets/categories.json");
            string categoriesProductsJsonString =
                File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, usersJsonString));
            //Console.WriteLine(ImportProducts(context, productsJsonString));
            //Console.WriteLine(ImportCategories(context, categoriesJsonString));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJsonString));

            string result = string.Empty;
            //result = GetProductsInRange(context);
            //result = GetSoldProducts(context);
            //result = GetCategoriesByProductsCount(context);
            //result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert
                .DeserializeObject<List<ImportUserDto>>(inputJson);

            InitializeMapper();

            var mappedUsers = mapper.Map<List<User>>(users);

            context.Users.AddRange(mappedUsers);

            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert
                .DeserializeObject<List<ImportProductDto>>(inputJson);

            InitializeMapper();

            var mappedProducts = mapper.Map<List<Product>>(products);

            context.Products.AddRange(mappedProducts);

            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                .DeserializeObject<List<ImportCategoryDto>>(inputJson)
                .Where(c => !string.IsNullOrEmpty(c.Name));

            InitializeMapper();

            var mappedCategories = mapper.Map<List<Category>>(categories);

            context.Categories.AddRange(mappedCategories);

            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert
                .DeserializeObject<List<ImportCategoryProductDto>>(inputJson);

            InitializeMapper();

            var mappedCategoriesProducts = mapper.Map<List<CategoryProduct>>(categoriesProducts);

            context.CategoryProducts.AddRange(mappedCategoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {mappedCategoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500
                    && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();

            JsonSerializerSettings jsonSettings = GetJsonSettings(NullValueHandling.Include);

            string result = JsonConvert.SerializeObject(products, jsonSettings);

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var userWithProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .ToArray();

            JsonSerializerSettings jsonSettings = GetJsonSettings(NullValueHandling.Include);

            string result = JsonConvert.SerializeObject(userWithProducts, jsonSettings);

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Where(c => c.CategoryProducts.Any())
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2"),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")
                })
                .ToArray();

            JsonSerializerSettings jsonSettings = GetJsonSettings(NullValueHandling.Include);

            string result = JsonConvert.SerializeObject(categories, jsonSettings);

            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .ToArray();

            var usersCountAndProducts = new
            {
                UsersCount = users.Length,
                Users = users
            };

            JsonSerializerSettings jsonSettings = GetJsonSettings(NullValueHandling.Ignore);

            string result = JsonConvert.SerializeObject(usersCountAndProducts, jsonSettings);

            return result;
        }

        private static void InitializeMapper()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

        private static JsonSerializerSettings GetJsonSettings(NullValueHandling handling)
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = handling,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };
        }
    }
}