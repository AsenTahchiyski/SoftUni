using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using NewsDB.Models;

namespace NewsDB.ConsoleClient
{
    public class NewsDBMain
    {
        static void Main()
        {
            var context = new Data.NewsDB();
            var firstNewsFirstUser = context.News.OrderBy(n => n.Id).First();

            var context2 = new Data.NewsDB();
            var firstNewsSecondUser = context2.News.OrderBy(n => n.Id).First();

            firstNewsFirstUser.Content = "Гала заля Драго с чай в ефир, леят му куршум";
            firstNewsSecondUser.Content = "Митьо Очите сменя името си на Митьо Мехура";

            context.SaveChanges();
            //try
            //{
                context2.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    Console.WriteLine("Error: Record has been updated meanwhile, try again after reopening it.");
            //    Console.WriteLine(ex.Message);
            //}
        }

        static void UpdateNewsContent(Data.NewsDB context)
        {
            Console.Write("Enter id of the news you want to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter new content: ");
            string newContent = Console.ReadLine();
            News newsToEdit = null;
            try
            {
                newsToEdit = context.News
                .Where(n => n.Id == id)
                .First();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("News with id {0} not found.", id);
                return;
            }

            newsToEdit.Content = newContent;
            context.SaveChanges();
            Console.WriteLine("News ID {0} updated successfully.", id);
        }

        static void SeedNewsData(Data.NewsDB context)
        {
            context.News.AddRange(new[] {
                new News("Митьо очите се прекръсти на Митьо Мехура"),
                new News("Шведи откриват смисълът на живота, масони ги колят"),
                new News("Германски крайно-десни формации на лов за емигранти"),
                new News("Азис с нов клип в МТВ (Междугалактическа ТелеВизия)"),
                new News("Путин ще представя Русия на Евровизия 2017"),
                });
            context.SaveChanges();
        }
    }
}
