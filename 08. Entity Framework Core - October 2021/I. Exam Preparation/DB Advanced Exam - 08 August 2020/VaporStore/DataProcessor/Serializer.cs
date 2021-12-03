namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore.Internal;

    using Data;
    using Data.Models.Enums;
    using ExportDto;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name));

            var exportGenres = genres
                .ToArray()
                .Select(g => new
                {
                    g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(g => g.Purchases.Count > 0)
                        .Select(g => new
                        {
                            g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = g.GameTags.Select(gt => gt.Tag.Name).Join(),
                            Players = g.Purchases.Count

                        })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id),
                    TotalPlayers = g.Games.Sum(g => g.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();

            var result = JsonConvert.SerializeObject(exportGenres, settings);

            return result.TrimEnd();
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            StringBuilder result = new StringBuilder();

            PurchaseType purchaseType = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .Where(u => u.Cards.Any(c => c.Purchases.Any()));

            var exportUsers = users
                .ToArray()
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseType)
                        .OrderBy(p => p.Date)
                        .Select(p => new ExportPurchaseDto
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .ToArray(),
                    TotalSpent = context.Purchases
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseType)
                        .Sum(p => p.Game.Price)

                })
                .Where(u => u.Purchases.Count() > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            XmlSerializer serializer = GetSerializer("Users", typeof(ExportUserDto[]));
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

        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
    }
}