namespace BookShop
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    using Data;
    using Initializer;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);

            string result = string.Empty;
            //result = GetBooksByAgeRestriction(context, Console.ReadLine());
            //result = GetGoldenBooks(context);
            //result = GetBooksByPrice(context);
            //result = GetBooksNotReleasedIn(context, int.Parse(Console.ReadLine()));
            //result = GetBooksByCategory(context, Console.ReadLine());
            //result = GetBooksReleasedBefore(context, Console.ReadLine());
            //result = GetAuthorNamesEndingIn(context, Console.ReadLine());
            //result = GetBookTitlesContaining(context, Console.ReadLine());
            //result = GetBooksByAuthor(context, Console.ReadLine());
            //result = CountBooks(context, int.Parse(Console.ReadLine())).ToString();
            //result = CountCopiesByAuthor(context);
            //result = GetTotalProfitByCategory(context);
            //result = GetMostRecentBooks(context);
            //IncreasePrices(context);
            //result = RemoveBooks(context).ToString();

            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder result = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .ToArray()
                .Where(b => b.AgeRestriction.ToString().ToLower() == ageRestriction.ToString().ToLower())
                .OrderBy(b => b.Title)
                .Select(b => new { b.Title })
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine(b.Title);
            }

            return result.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Copies < 5000
                    && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title })
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine(b.Title);
            }

            return result.ToString().Trim();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40m)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return result.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder result = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate.HasValue
                    && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title })
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine(b.Title);
            }

            return result.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            string[] categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> unorderedBooks = new List<string>();

            foreach (var category in categories)
            {
                var currentBooksByCategory = context
                    .Books
                    .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == category))
                    .Select(b => b.Title)
                    .ToList();

                unorderedBooks.AddRange(currentBooksByCategory);
            }

            string[] books = unorderedBooks
                .OrderBy(b => b)
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine(b);
            }

            return result.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder result = new StringBuilder();

            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate.HasValue
                    && b.ReleaseDate.Value < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return result.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var authors = context
                .Authors
                .ToArray()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToArray();

            foreach (var a in authors)
            {
                result.AppendLine(a.FullName);
            }

            return result.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var books = context
                .Books
                .OrderBy(b => b.Title)
                .Where(b => b.Title.ToLower()
                    .Contains(input.ToLower()))
                .Select(b => new { b.Title })
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine(b.Title);
            }

            return result.ToString().Trim();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();

            var books = context
                .Books
                .Where(b => b
                    .Author.LastName.ToLower()
                    .StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} ({b.AuthorName})");
            }

            return result.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCount = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var authors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToArray();

            foreach (var a in authors)
            {
                result.AppendLine($"{a.AuthorName} - {a.TotalCopies}");
            }

            return result.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(a => a.Profit)
                .ToArray();

            foreach (var c in categories)
            {
                result.AppendLine($"{c.Name} ${c.Profit}");
            }

            return result.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c
                        .CategoryBooks
                        .Where(cb => cb.Book.ReleaseDate.HasValue)
                        .Select(b => b.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .ThenBy(b => b.Title)
                        .Select(b => new
                        {
                            b.Title,
                            b.ReleaseDate.Value.Year
                        })
                        .Take(3)
                        .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            foreach (var c in categories)
            {
                result.AppendLine($"--{c.Name}");
                foreach (var b in c.Books)
                {
                    result.AppendLine($"{b.Title} ({b.Year})");
                }
            }

            return result.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.HasValue
                    && b.ReleaseDate.Value.Year < 2010);

            foreach (var b in books)
            {
                b.Price += 5m;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context
                .Books
                .Where(b => b.Copies < 4200);

            var booksWithCategoriesToDelete = context
                .BooksCategories
                .Where(bc => booksToDelete.Select(b => b.BookId).Contains(bc.BookId));

            int booksCount = booksToDelete.Count();

            context.BooksCategories.RemoveRange(booksWithCategoriesToDelete);

            context.Books.RemoveRange(booksToDelete);

            context.SaveChanges();

            return booksCount;
        }
    }
}
