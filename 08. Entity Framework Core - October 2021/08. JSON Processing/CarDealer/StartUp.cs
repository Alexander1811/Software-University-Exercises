namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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
        private static readonly IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string suppliersJsonString =
                 File.ReadAllText("../../../Datasets/suppliers.json");
            string partsJsonString =
                 File.ReadAllText("../../../Datasets/parts.json");
            string carsJsonString =
                File.ReadAllText("../../../Datasets/cars.json");
            string customersJsonString =
                 File.ReadAllText("../../../Datasets/customers.json");
            string salesJsonString =
                 File.ReadAllText("../../../Datasets/sales.json");

            string result = string.Empty;
            //Console.WriteLine(ImportSuppliers(context, suppliersJsonString));
            //Console.WriteLine(ImportParts(context, partsJsonString));
            //Console.WriteLine(ImportCars(context, carsJsonString));
            //Console.WriteLine(ImportCustomers(context, customersJsonString));
            //Console.WriteLine(ImportSales(context, salesJsonString));
            //result = GetOrderedCustomers(context);
            //result = GetCarsFromMakeToyota(context);
            //result = GetLocalSuppliers(context);
            //result = GetCarsWithTheirListOfParts(context);
            //result = GetTotalSalesByCustomer(context);
            //result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var importSuppliers = JsonConvert
                .DeserializeObject<ImportSupplierDto[]>(inputJson);

            var mappedSuppliers = mapper.Map<Supplier[]>(importSuppliers);

            context.Suppliers.AddRange(mappedSuppliers);

            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers.Select(s => s.Id);

            var importParts = JsonConvert
                .DeserializeObject<ImportPartDto[]>(inputJson)
                .Where(p => supplierIds.Contains(p.SupplierId));

            var mappedParts = mapper.Map<Part[]>(importParts);

            context.Parts.AddRange(mappedParts);

            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var importCars = JsonConvert
                .DeserializeObject<ImportCarDto[]>(inputJson);

            var mappedCars = GetMappedCars(importCars);

            context.Cars.AddRange(mappedCars);

            context.SaveChanges();

            return $"Successfully imported {mappedCars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var importCustomers = JsonConvert
                .DeserializeObject<ImportCustomerDto[]>(inputJson);

            var mappedCustomers = mapper.Map<Customer[]>(importCustomers);

            context.Customers.AddRange(mappedCustomers);

            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var carIds = context.Cars.Select(c => c.Id);

            var importSales = JsonConvert
                .DeserializeObject<ImportSaleDto[]>(inputJson)
                .Where(s => carIds.Contains(s.CarId));

            var mappedSales = mapper.Map<Sale[]>(importSales);

            context.Sales.AddRange(mappedSales);

            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
               .OrderBy(c => c.BirthDate)
               .ThenBy(c => c.IsYoungDriver)
               .Select(c => new
               {
                   c.Name,
                   BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                   c.IsYoungDriver
               })
               .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();

            string result = JsonConvert.SerializeObject(customers, settings);

            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();

            string result = JsonConvert.SerializeObject(cars, settings);

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();

            string result = JsonConvert.SerializeObject(suppliers, settings);

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,
                    },
                    parts = c.PartCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();

            string result = JsonConvert.SerializeObject(cars, settings);

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();
            settings.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string result = JsonConvert.SerializeObject(customers, settings);

            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance,
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars.Sum(p => p.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(c => c.Part.Price) - (s.Car.PartCars.Sum(y => y.Part.Price) * (s.Discount / 100))).ToString("f2")
                })
                .Take(10)
                .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();

            string result = JsonConvert.SerializeObject(sales, settings);

            return result;
        }

        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                Formatting = Formatting.Indented
            };
        }

        private static Car[] GetMappedCars(ImportCarDto[] importCars)
        {
            var mappedCars = new List<Car>();

            foreach (var c in importCars)
            {
                var car = mapper.Map<ImportCarDto, Car>(c);

                var partIds = c.PartsId
                    .Distinct()
                    .ToList();

                if (partIds == null) { continue; }

                partIds.ForEach(p =>
                {
                    var currentPair = new PartCar() { Car = car, PartId = p };

                    car.PartCars.Add(currentPair);
                });

                mappedCars.Add(car);
            }

            return mappedCars.ToArray();
        }
    }
}