namespace DataLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        private Random random = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DataLayer.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            var authors = new List<Author>();
            using (var reader = new StreamReader("../../../../authors.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var author = new Author(data[1], data[0]);
                    authors.Add(author);
                    line = reader.ReadLine();
                }
            }

            var categories = new List<Category>();
            using (var reader = new StreamReader("../../../../categories.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    categories.Add(new Category(line));
                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader("../../../../books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = random.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (Editions)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3], CultureInfo.InvariantCulture);
                    var ageRestriction = (AgeRestrictions)int.Parse(data[4]);
                    var title = data[5];
                    var book = new Book(title, edition, author, price, copies, ageRestriction, releaseDate);
                    book.Categories.Add(categories[random.Next(0, categories.Count)]);
                    context.Books.Add(book);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
