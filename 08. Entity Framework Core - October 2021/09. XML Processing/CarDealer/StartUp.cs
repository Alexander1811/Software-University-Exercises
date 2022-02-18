namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using AutoMapper;
    
    using Data;
    using DTO.Export;
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

            string suppliersXmlString =
                File.ReadAllText("../../../Datasets/suppliers.xml");
            string partsXmlString =
                 File.ReadAllText("../../../Datasets/parts.xml");
            string carsXmlString =
                  File.ReadAllText("../../../Datasets/cars.xml");
            string customersXmlString =
                  File.ReadAllText("../../../Datasets/customers.xml");
            string salesXmlString =
                  File.ReadAllText("../../../Datasets/sales.xml");

            string result = string.Empty;
            //Console.WriteLine(ImportSuppliers(context, suppliersXmlString));
            //Console.WriteLine(ImportParts(context, partsXmlString));
            //Console.WriteLine(ImportCars(context, carsXmlString));
            //Console.WriteLine(ImportCustomers(context, customersXmlString));
            //Console.WriteLine(ImportSales(context, salesXmlString));
            //result = GetCarsWithDistance(context);
            //result = GetCarsFromMakeBmw(context);
            //result = GetLocalSuppliers(context);
            //result = GetCarsWithTheirListOfParts(context);
            //result = GetTotalSalesByCustomer(context);
            //result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = GetSerializer("Suppliers", typeof(ImportSupplierDto[]));

            using StringReader reader = new StringReader(inputXml);

            var importSuppliers = (ImportSupplierDto[]) serializer.Deserialize(reader);

            var mappedSuppliers = mapper.Map<Supplier[]>(importSuppliers);

            context.Suppliers.AddRange(mappedSuppliers);

            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var supplierIds = context.Suppliers.Select(s => s.Id);

            XmlSerializer serializer = GetSerializer("Parts", typeof(ImportPartDto[]));

            using StringReader reader = new StringReader(inputXml);

            var importPartsDtos = (ImportPartDto[]) serializer.Deserialize(reader);
            var importParts = importPartsDtos
                .Where(p => supplierIds.Contains(p.SupplierId));

            var mappedParts = mapper.Map<Part[]>(importParts);

            context.Parts.AddRange(mappedParts);

            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = GetSerializer("Cars", typeof(ImportCarDto[]));
            using StringReader reader = new StringReader(inputXml);

            var importCars = (ImportCarDto[]) serializer.Deserialize(reader);

            var mappedCars = GetMappedCars(importCars);

            context.Cars.AddRange(mappedCars);

            context.SaveChanges();

            return $"Successfully imported {mappedCars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = GetSerializer("Customers", typeof(ImportCustomerDto[]));

            using StringReader reader = new StringReader(inputXml);

            var importCustomers = (ImportCustomerDto[]) serializer.Deserialize(reader);

            var mappedCustomers = mapper.Map<Customer[]>(importCustomers);

            context.Customers.AddRange(mappedCustomers);

            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var carIds = context.Cars.Select(c => c.Id);

            XmlSerializer serializer = GetSerializer("Sales", typeof(ImportSaleDto[]));

            using StringReader reader = new StringReader(inputXml);

            var importSalesDtos = (ImportSaleDto[]) serializer.Deserialize(reader);
            var importSales = importSalesDtos
                .Where(s => carIds.Contains(s.CarId));

            var mappedSales = mapper.Map<Sale[]>(importSales);

            context.Sales.AddRange(mappedSales);

            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder result = new StringBuilder();

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10);

            var exportCars = mapper
                .ProjectTo<ExportCarWithDistanceDto>(cars)
                .ToArray();

            XmlSerializer serializer = GetSerializer("cars", typeof(ExportCarWithDistanceDto[]));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportCars, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder result = new StringBuilder();

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);

            var exportCars = mapper
                .ProjectTo<ExportCarFromMakeBmwDto>(cars)
                .ToArray();

            XmlSerializer serializer = GetSerializer("cars", typeof(ExportCarFromMakeBmwDto[]));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportCars, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder result = new StringBuilder();

            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter);

            var exportSuppliers = mapper
                .ProjectTo<ExportLocalSupplierDto>(suppliers)
                .ToArray();

            XmlSerializer serializer = GetSerializer("suppliers", typeof(ExportLocalSupplierDto[]));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportSuppliers, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder result = new StringBuilder();

            var cars = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5);

            var exportCars = mapper
                .ProjectTo<ExportCarWithTheirListOfPartsDto>(cars)
                .ToArray();

            XmlSerializer serializer = GetSerializer("cars", typeof(ExportCarWithTheirListOfPartsDto[]));

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportCars, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder result = new StringBuilder();

            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1);

            var exportCustomers = mapper
                .ProjectTo<ExportTotalSalesByCustomerDto>(customers)
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer serializer = GetSerializer("customers", typeof(ExportTotalSalesByCustomerDto[]));

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportCustomers, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder result = new StringBuilder();

            var sales = context.Sales;

            var exportSales = mapper
                .ProjectTo<ExportSaleWithAppliedDiscountDto>(sales)
                .ToArray();

            XmlSerializer serializer = GetSerializer("sales", typeof(ExportSaleWithAppliedDiscountDto[]));

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportSales, GetSerializerNamespaces());
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

        private static Car[] GetMappedCars(ImportCarDto[] importCars)
        {
            var mappedCars = new List<Car>();

            foreach (var c in importCars)
            {
                var car = mapper.Map<ImportCarDto, Car>(c);

                var partIds = c.Parts
                    .Select(p => p.Id)
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