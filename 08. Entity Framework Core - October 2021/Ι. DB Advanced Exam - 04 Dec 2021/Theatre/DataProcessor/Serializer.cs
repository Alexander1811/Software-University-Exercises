namespace Theatre.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls
                    && t.Tickets.Count >= 20);

            var exportTheatres = theatres
                .ToArray()
                .Select(th => new
                {
                    th.Name,
                    Halls = th.NumberOfHalls,
                    TotalIncome = th.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Sum(t => t.Price),
                    Tickets = th.Tickets
                        .ToArray()
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .OrderByDescending(t => t.Price)
                        .Select(t => new
                        {
                            t.Price,
                            t.RowNumber
                        })
                })
                .OrderByDescending(th => th.Halls)
                .ThenBy(th => th.Name)
                .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();

            var result = JsonConvert.SerializeObject(exportTheatres, settings);

            return result.TrimEnd();
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder result = new StringBuilder();

            var plays = context.Plays
                .Where(p => p.Rating <= rating);

            var exportPlays = plays
                .ToArray()
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(a => a.IsMainCharacter == true)
                        .ToArray()
                        .OrderByDescending(a => a.FullName)
                        .Select(a => new ExportActorDto
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .ToArray()

                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            XmlSerializer serializer = GetSerializer("Plays", typeof(ExportPlayDto[]));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportPlays, GetSerializerNamespaces());
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
