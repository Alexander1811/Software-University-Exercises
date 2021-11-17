namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            string result;
            //result = ExportAlbumsInfo(context, 9);
            //result = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder result = new StringBuilder();

            var albums = context
                .Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a
                        .Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .Select(s => new
                        {
                            s.Name,
                            s.Price,
                            SongWriterName = s.Writer.Name
                        })
                        .ToArray(),
                    AlbumPrice = a.Price
                })
                .ToArray();


            foreach (var a in albums)
            {
                result.AppendLine($"-AlbumName: {a.Name}");
                result.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                result.AppendLine($"-ProducerName: {a.ProducerName}");
                result.AppendLine("-Songs:");

                int i = 1;

                foreach (var s in a.Songs)
                {
                    result.AppendLine($"---#{i}");
                    result.AppendLine($"---SongName: {s.Name}");
                    result.AppendLine($"---Price: {s.Price:f2}");
                    result.AppendLine($"---Writer: {s.SongWriterName}");

                    i++;
                }
                result.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");
            }

            return result.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder result = new StringBuilder();

            var songs = context
                .Songs
                .ToArray()
                .Where(s => s.Duration > TimeSpan.FromSeconds(duration))            
                .Select(s => new
                {
                    s.Name,
                    PeformerName = s.SongPerformers.Count != 0
                        ? s.SongPerformers.First().Performer.FirstName + " " + s.SongPerformers.First().Performer.LastName
                        : "",
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PeformerName)
                .ToArray();

            int i = 1;
            foreach (var s in songs)
            {
                result.AppendLine($"-Song #{i}");
                result.AppendLine($"---SongName: {s.Name}");
                result.AppendLine($"---Writer: {s.WriterName}");
                result.AppendLine($"---Performer: {s.PeformerName}");
                result.AppendLine($"---AlbumProducer: {s.AlbumProducer}");
                result.AppendLine($"---Duration: {s.Duration}");

                i++;
            }

            return result.ToString().Trim();
        }
    }
}
