namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            XmlSerializer serializer = GetSerializer("Plays", typeof(ImportPlayDto[]));

            using StringReader reader = new StringReader(xmlString);

            var importPlays = (ImportPlayDto[]) serializer.Deserialize(reader);

            var mappedPlays = new List<Play>();
            foreach (var p in importPlays)
            {
                if (!IsValid(p))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDuration = TimeSpan.TryParseExact(p.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan duration);

                if (!isValidDuration)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.Hours < 1)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = p.Title,
                    Duration = duration,
                    Rating = p.Rating,
                    Genre = (Genre) Enum.Parse(typeof(Genre), p.Genre),
                    Description = p.Description,
                    Screenwriter = p.Screenwriter
                };

                mappedPlays.Add(play);

                result.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(mappedPlays);

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            XmlSerializer serializer = GetSerializer("Casts", typeof(ImportCastDto[]));

            using StringReader reader = new StringReader(xmlString);

            var importCasts = (ImportCastDto[]) serializer.Deserialize(reader);

            var mappedCasts = new List<Cast>();
            foreach (var c in importCasts)
            {
                if (!IsValid(c))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidMainCharacter = bool.TryParse(c.IsMainCharacter, out bool isMainCharacter);

                if (!isValidMainCharacter)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = c.FullName,
                    IsMainCharacter = isMainCharacter,
                    PhoneNumber = c.PhoneNumber,
                    PlayId = c.PlayId
                };

                mappedCasts.Add(cast);

                result.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, isMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(mappedCasts);

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            var importTheatres = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            var mappedTheatres = new List<Theatre>();
            foreach (var th in importTheatres)
            {
                if (!IsValid(th))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = th.Name,
                    NumberOfHalls = th.NumberOfHalls,
                    Director = th.Director,
                };

                var mappedTickets = new List<Ticket>();
                foreach (var t in th.Tickets)
                {

                    if (!IsValid(t))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber,
                        PlayId = t.PlayId
                    };

                    mappedTickets.Add(ticket);
                }

                theatre.Tickets = mappedTickets;

                mappedTheatres.Add(theatre);

                result.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(mappedTheatres);

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }

        private static XmlSerializer GetSerializer(string rootName, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(rootName));
        }
    }
}
