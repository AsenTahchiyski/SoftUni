using System;
using System.Linq;
using DataLayer;
using Models;

namespace BookShopSystem.ConsoleClient
{
    public class BookShopMain
    {
        static void Main()
        {
            var context = new BookShopContext();
            var bookCount = context.Books.Count();

            // 1.	Get all books after the year 2000. Select only their titles
            //var allBooksAfter2k = context.Books
            //    .Where(b => b.ReleaseDate > new DateTime(2000, 12, 31))
            //    .Select(b => b.Title);
            //foreach (var book in allBooksAfter2k)
            //{
            //    Console.WriteLine(book);
            //}

            // 2.	Get all authors with at least one book with release date before 1990. Select their first name and last name.
            //var releaseDateBefore90s = new DateTime(1990, 1, 1);
            //var authorsBefore90s = context.Authors
            //    .Where(a => a.Books.Any(b => b.ReleaseDate < releaseDateBefore90s))
            //    .Select(a => new
            //    {
            //        a.FirstName,
            //        a.LastName
            //    });
            //foreach (var author in authorsBefore90s)
            //{
            //    Console.WriteLine("{0} {1}", author.FirstName, author.LastName);
            //}

            // 3.	Get all authors, ordered by the number of their books (descending). Select their first name, last name and book count.	
            //var authorsByBookCount = context.Authors
            //    .OrderByDescending(a => a.Books.Count)
            //    .Select(a => new
            //    {
            //        a.FirstName,
            //        a.LastName,
            //        a.Books.Count
            //    });
            //foreach (var author in authorsByBookCount)
            //{
            //    Console.WriteLine("{0} {1} ({2} books)", author.FirstName, author.LastName, author.Count);
            //}

            // 4.	Get all books from author George Powell, ordered by their release date (descending), then by book title (ascending). Select the book's title, release date and copies.
            //var booksByGPowell = context.Books
            //    .Where(b => b.Author.FirstName == "George" && b.Author.LastName == "Powell")
            //    .OrderByDescending(b => b.ReleaseDate)
            //    .ThenBy(b => b.Title)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        b.ReleaseDate,
            //        b.Copies
            //    });
            //foreach (var book in booksByGPowell)
            //{
            //    Console.WriteLine("{0} ({1:dd-MM-yyyy}) - {2} copies", book.Title, book.ReleaseDate, book.Copies);
            //}

            // 5.	Get the most recent books by categories. The categories should be ordered by total book count. Only take the top 3 most recent books from each category - ordered by date (descending), then by title (ascending). Select the category name, total book count and for each book - its title and release date.
            
            // unfinished!
            //var top3booksByCategory = context.Books
            //    .GroupBy(b => b.Categories)
            //    .SelectMany(g => g
            //        .OrderByDescending(b => b.ReleaseDate)
            //        .ThenBy(b => b.Title)
            //        .Take(3)
            //        .Select(b => new
            //        {
            //            b.Title,
            //            b.ReleaseDate,
            //            b.Categories
            //        }));
        }
    }
}
