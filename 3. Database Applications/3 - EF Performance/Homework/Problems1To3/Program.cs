using System;
using System.Diagnostics;
using System.Linq;

namespace Problems1To3
{
    public class Program
    {
        static void Main()
        {
            var context = new AdsEntities();

            // Problem 1. Using Entity Framework write a SQL query to select all ads from the database and later print their title, status, category, town and user. 
            // 1.1. Do not use Include(…) for the relationships of the Ads. Check how many SQL commands are executed with the SQL ExpressProfiler (or a similar tool).
            //var result1 = context.Ads;
            //foreach (var ad in result1)
            //{
            //    Console.WriteLine("{0} {1} \n{2} {3} {4}", ad.Title, ad.AdStatus, ad.Category, ad.Town, ad.AspNetUser);
            //}

            // 28 sql queries

            // 1.2. Add Include(…) to select statuses, categories, towns and users along with all ads. Compare the number of executed SQL statements and the performance before and after adding Include(…).
            //var result2 = context.Ads
            //    .Include("AdStatus")
            //    .Include("Category")
            //    .Include("Town")
            //    .Include("AspNetUser");
            //foreach (var ad in result2)
            //{
            //    Console.WriteLine("{0} {1} \n{2} {3} {4}", ad.Title, ad.AdStatus, ad.Category, ad.Town, ad.AspNetUser);
            //}

            // 1 sql query

            // Problem 2. Using Entity Framework select all ads from the database, then invoke ToList(), then filter the categories whose status is Published; then select the ad title, category, town and date, then invoke ToList() again and finally order the ads by publish date. Rewrite the same query in a more optimized way and compare the performance.
            // 2.1. Slow
            //var totalAds = context.Ads.Count(); // connect to DB before measure starts

            //var timer = new Stopwatch();
            //timer.Start();
            //var result3 = context.Ads
            //    .ToList()
            //    .Where(a => a.AdStatus.Status == "Published")
            //    .Select(a => new
            //    {
            //        a.Title,
            //        a.Category,
            //        a.Town,
            //        a.Date
            //    })
            //    .ToList()
            //    .OrderBy(a => a.Date);

            //foreach (var ad in result3)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", ad.Title, ad.Category, ad.Town, ad.Date);
            //}

            //timer.Stop();
            //var slowTicks = timer.ElapsedTicks;
            //// 2.2. Optimized
            //timer.Restart();
            //var result4 = context.Ads
            //    .Where(a => a.AdStatus.Status == "Published")
            //    .Select(a => new
            //    {
            //        a.Title,
            //        a.Category,
            //        a.Town,
            //        a.Date
            //    })
            //    .OrderBy(a => a.Date)
            //    .ToList();

            //foreach (var ad in result4)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", ad.Title, ad.Category, ad.Town, ad.Date);
            //}

            //timer.Stop();

            //Console.WriteLine("Slow: {0} ticks", slowTicks); // 42 queries
            //Console.WriteLine("Optimized: {0} ticks", timer.ElapsedTicks); // 3 queries

            // Problem 3. Write a program to compare the execution speed between these two scenarios:
            // •	Select everything from the Ads table and print only the ad title.
            // •	Select the ad title from Ads table and print it.
            var timer = new Stopwatch();

            timer.Start();
            var result5 = context.Ads;
            foreach (var ad in result5)
            {
                Console.WriteLine(ad.Title);
            }

            timer.Stop();
            var slow = timer.ElapsedTicks;

            timer.Restart();
            var result6 = context.Ads
                .Select(a => a.Title);
            foreach (var ad in result6)
            {
                Console.WriteLine(ad);
            }

            timer.Stop();

            Console.WriteLine("--> Slow: {0} ticks", slow);
            Console.WriteLine("--> Fast: {0} ticks", timer.ElapsedTicks);
        }
    }
}
