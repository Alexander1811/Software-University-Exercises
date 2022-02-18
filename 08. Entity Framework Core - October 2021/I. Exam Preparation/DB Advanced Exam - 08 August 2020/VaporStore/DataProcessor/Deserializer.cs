namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedGame
            = "Added {0} ({1}) with {2} tags";

        private const string SuccessfullyImportedUser
             = "Imported {0} with {1} cards";

        private const string SuccessfullyImportedPurchase
             = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            var importGames = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var mappedGames = new List<Game>();
            foreach (var g in importGames)
            {
                if (!IsValid(g))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (g.Price < 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Developer mappedDeveloper = context.Developers.SingleOrDefault(d => d.Name == g.Developer);
                if (mappedDeveloper == null)
                {
                    mappedDeveloper = new Developer() { Name = g.Developer };

                    context.Developers.Add(mappedDeveloper);
                }

                Genre mappedGenre = context.Genres.SingleOrDefault(gn => gn.Name == g.Genre);
                if (mappedGenre == null)
                {
                    mappedGenre = new Genre() { Name = g.Genre };

                    context.Genres.Add(mappedGenre);
                }

                Game game = new Game()
                {
                    Name = g.Name,
                    Price = g.Price,
                    ReleaseDate = DateTime.ParseExact(g.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = mappedDeveloper,
                    Genre = mappedGenre
                };

                var mappedGameTags = new List<GameTag>();
                foreach (var tagName in g.Tags)
                {
                    Tag tag = context.Tags.SingleOrDefault(t => t.Name == tagName);

                    if (tag == null)
                    {
                        tag = new Tag() { Name = tagName };

                        context.Tags.Add(tag);
                    }

                    GameTag gameTag = new GameTag()
                    {
                        Game = game,
                        Tag = tag
                    };

                    mappedGameTags.Add(gameTag);
                }

                game.GameTags = mappedGameTags;

                context.SaveChanges();

                mappedGames.Add(game);

                result.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(mappedGames);

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            var importUsers = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var mappedUsers = new List<User>();
            foreach (var u in importUsers)
            {
                if (!IsValid(u))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var c in u.Cards)
                {
                    if (!IsValid(c))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                }

                User user = new User()
                {
                    FullName = u.FullName,
                    Username = u.Username,
                    Email = u.Email,
                    Age = u.Age,
                    Cards = u.Cards
                        .Select(c => new Card()
                        {
                            Number = c.Number,
                            Cvc = c.Cvc,
                            Type = (CardType) Enum.Parse(typeof(CardType), c.Type)
                        })
                        .ToArray()
                };

                mappedUsers.Add(user);

                result.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(mappedUsers);

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            XmlSerializer serializer = GetSerializer("Purchases", typeof(ImportPurchaseDto[]));

            using StringReader reader = new StringReader(xmlString);

            var importProjects = (ImportPurchaseDto[]) serializer.Deserialize(reader);

            var mappedPurchases = new List<Purchase>();
            foreach (var p in importProjects)
            {
                if (!IsValid(p))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Card card = context.Cards.Single(c => c.Number == p.Card);
                Game game = context.Games.Single(c => c.Name == p.Title);
                Purchase purchase = new Purchase()
                {
                    Type = (PurchaseType) Enum.Parse(typeof(PurchaseType), p.Type),
                    ProductKey = p.Key,
                    Card = card,
                    Date = DateTime.ParseExact(p.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Game = game
                };

                mappedPurchases.Add(purchase);

                result.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.Game.Name, card.User.Username));
            }

            context.Purchases.AddRange(mappedPurchases);

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static XmlSerializer GetSerializer(string rootName, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(rootName));
        }
    }
}