using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Articles2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            List<Article> sortedArticles = new List<Article>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();

                Article current = new Article(input[0], input[1], input[2]);

                articles.Add(current);
            }

            string criteria = Console.ReadLine();

            switch (criteria)
            {
                case "title":
                    sortedArticles = articles.OrderBy(e => e.Title).ToList();
                    break;
                case "content":
                    sortedArticles = articles.OrderBy(e => e.Content).ToList();
                    break;
                case "author":
                    sortedArticles = articles.OrderBy(e => e.Author).ToList();
                    break;
                default:
                    break;
            }

            foreach (Article article in sortedArticles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}