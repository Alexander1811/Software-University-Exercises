using System;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();
            Article article = new Article(input[0], input[1], input[2]);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ").ToArray();
                string action = cmd[0];
                string newContent = cmd[1];

                switch (action)
                {
                    case "Edit":
                        article.Edit(newContent);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(newContent);
                        break;
                    case "Rename":
                        article.Rename(newContent);
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine(article);
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

        public void Rename(string title)
        {
            Title = title;
        }
        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }


    }
}
