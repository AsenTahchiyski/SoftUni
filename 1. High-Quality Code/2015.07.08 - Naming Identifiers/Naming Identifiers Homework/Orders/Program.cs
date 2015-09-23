namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Program
    {
        internal static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var allCategories = dataMapper.GetAllCategories();
            var allProducts = dataMapper.GetAllProducts();
            var allOrders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            var mostExpensive5Products = dataMapper.Get5MostExpensiveProducts();

            Console.WriteLine(string.Join(Environment.NewLine, mostExpensive5Products));
            Console.WriteLine(new string('-', 10));

            // Number of products in each Category
            var numberOfProductsForEachCategory = allProducts
                .GroupBy(p => p.CatalogueId)
                .Select(grp => new { Category = allCategories.First(c => c.Id == grp.Key).Name, Count = grp.Count() })
                .ToList();

            foreach (var item in numberOfProductsForEachCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by Order quantity)
            var top5Products = allOrders
                .GroupBy(o => o.ProductId)
                .Select(grp => new { Product = allProducts.First(p => p.Id == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quantity) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);

            foreach (var item in top5Products)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable Category
            var mostProfitableCategory = allOrders
                .GroupBy(o => o.ProductId)
                .Select(g => new { catId = allProducts.First(p => p.Id == g.Key).CatalogueId, price = allProducts.First(p => p.Id == g.Key).UnitPrice, quantity = g.Sum(p => p.Quantity) })
                .GroupBy(gg => gg.catId)
                .Select(grp => new { categoryName = allCategories.First(c => c.Id == grp.Key).Name, totalQuantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.totalQuantity)
                .First();

            Console.WriteLine("{0}: {1}", mostProfitableCategory.categoryName, mostProfitableCategory.totalQuantity);
        }
    }
}
