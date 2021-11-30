namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using AutoMapper;

    using Data;
    using DTO.Import;
    using Models;
    using ProductShop.DTO.Export;

    public class StartUp
    {
        private static readonly IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string usersXmlString =
                File.ReadAllText("../../../Datasets/users.xml");
            string productsXmlString =
                File.ReadAllText("../../../Datasets/products.xml");
            string categoriesXmlString =
                File.ReadAllText("../../../Datasets/categories.xml");
            string categoriesProductsXmlString =
                File.ReadAllText("../../../Datasets/categories-products.xml");

            string result = string.Empty;
            //Console.WriteLine(ImportUsers(context, usersXmlString));
            //Console.WriteLine(ImportProducts(context, productsXmlString));
            //Console.WriteLine(ImportCategories(context, categoriesXmlString));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXmlString));
            //result = GetProductsInRange(context);
            //result = GetSoldProducts(context);
            //result = GetCategoriesByProductsCount(context);
            //result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = GetSerializer("Users", typeof(ImportUserDto[]));

            using StringReader reader = new StringReader(inputXml);

            var importUsers = (ImportUserDto[]) serializer.Deserialize(reader);

            var mappedUsers = mapper.Map<User[]>(importUsers);

            context.Users.AddRange(mappedUsers);

            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = GetSerializer("Products", typeof(ImportProductDto[]));

            using StringReader reader = new StringReader(inputXml);

            var importProducts = (ImportProductDto[]) serializer.Deserialize(reader);

            var mappedProducts = mapper.Map<Product[]>(importProducts);

            context.Products.AddRange(mappedProducts);

            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = GetSerializer("Categories", typeof(ImportCategoryDto[]));

            using StringReader reader = new StringReader(inputXml);

            var importCategories = (ImportCategoryDto[]) serializer.Deserialize(reader);

            var mappedCategories = mapper.Map<Category[]>(importCategories);

            context.Categories.AddRange(mappedCategories);

            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = GetSerializer("CategoryProducts", typeof(ImportCategoryProductDto[]));

            using StringReader reader = new StringReader(inputXml);

            var importCategoryProducts = (ImportCategoryProductDto[]) serializer.Deserialize(reader);

            var mappedCategoryProducts = mapper.Map<CategoryProduct[]>(importCategoryProducts);

            context.CategoryProducts.AddRange(mappedCategoryProducts);

            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var products = context.Products
                .Where(p => p.Price >= 500
                    && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10);

            var exportProducts = mapper
                .ProjectTo<ExportProductInRangeDto>(products)
                .ToArray();

            XmlSerializer serializer = GetSerializer("Products", typeof(ExportProductInRangeDto[]));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportProducts, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5);

            var exportUsers = mapper
                .ProjectTo<ExportSoldProductsByUserDto>(users)
                .ToArray();

            XmlSerializer serializer = GetSerializer("Users", typeof(ExportSoldProductsByUserDto[]));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportUsers, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var categories = context.Categories;

            var exportCategories = mapper
                .ProjectTo<ExportCategoryByProductsCountDto>(categories)
                .OrderByDescending(u => u.Count)
                .ThenBy(u => u.TotalRevenue)
                .ToArray();

            XmlSerializer serializer = GetSerializer("Categories", typeof(ExportCategoryByProductsCountDto[]));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportCategories, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1);

            var exportUsers = new ExportUsersWithProductsDto()
            {
                Count = users.Count(),
                Users = users
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .Take(10)
                    .Select(u => new ExportUserWithProductsDto()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProducts = new ExportProductsByUserDto()
                        {
                            Count = u.ProductsSold.Count,
                            Products = u.ProductsSold
                                .OrderByDescending(p => p.Price)
                                .Select(p => new ExportSoldProductDto()
                                {
                                    Name = p.Name,
                                    Price = p.Price
                                })
                                .ToArray()
                        }
                    })
                    .ToArray()
            };

            XmlSerializer serializer = GetSerializer("Users", typeof(ExportUsersWithProductsDto));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportUsers, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        private static XmlSerializer GetSerializer(string rootName, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(rootName));
        }

        private static XmlSerializerNamespaces GetSerializerNamespaces()
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            return namespaces;
        }
    }
}