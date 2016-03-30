using System;

namespace p3.CollectionOfProducts
{
    class Program
    {
        static void Main()
        {
            var productDb = new Database();

            // seed db
            productDb.Add(new Product("ID01", "Bananas", "Chiquitta", 2.50));
            productDb.Add(new Product("ID02", "Apples", "Bai Pesho", 1.50));
            productDb.Add(new Product("ID03", "Nexus 6", "Samsung", 999.00));
            productDb.Add(new Product("ID04", "Yoga 4", "Lenovo", 1899.99));
            productDb.Add(new Product("ID05", "Yoga 10", "Lenovo", 2999.99));
            productDb.Add(new Product("ID06", "Veyron", "Bugatti", 1500000.00));
            productDb.Add(new Product("ID07", "Cap", "Metalurg Pernik", 0.05));
            productDb.Add(new Product("ID08", "Golf Mk2", "Pernik Tuning", 1999.50));
            productDb.Add(new Product("ID09", "Salmon Salad", "IKEA", 6.90));
            productDb.Add(new Product("ID10", "Tomatoes", "Bai Pesho", 2.00));
            productDb.Add(new Product("ID11", "Yogurt", "Vereya", 0.90));
            productDb.Add(new Product("ID12", "Egg", "Chicken Farm Cheplyat", 0.29));
            productDb.Add(new Product("ID13", "Raspberry Wine", "Trastena", 8.50));
            productDb.Add(new Product("ID14", "Rakiya 700ml", "Bai Pesho", 5.50));
            productDb.Add(new Product("ID15", "Menta Peshtera", "Vinprom Peshtera", 7.50));
            productDb.Add(new Product("ID16", "Mastika Peshtera", "Vinprom Peshtera", 7.50));
            productDb.Add(new Product("ID17", "Milk 1l", "Vereya", 2.20));
            productDb.Add(new Product("ID18", "Pineapple", "Chiquitta", 3.50));
            productDb.Add(new Product("ID19", "Apples", "Baba Gicka", 1.60));
            productDb.Add(new Product("ID20", "Premium Lager", "Carlsberg", 1.50));
            productDb.Add(new Product("ID21", "Zagorka Retro", "Carlsberg", 1.20));
            productDb.Add(new Product("ID22", "Leffe Blonde", "Kamenitza", 1.90));
            productDb.Add(new Product("ID23", "Leffe Brune", "Kamenitza", 1.90));
            productDb.Add(new Product("ID24", "Stout", "Blek Pine", 4.50));
            productDb.Add(new Product("ID25", "IPA Limited Edition", "Blek Pine", 4.10));
            productDb.Add(new Product("ID26", "Duvel", "Duvel Moortgat", 4.50));
            productDb.Add(new Product("ID27", "Duvel Tripel Hop 2016", "Duvel Moortgat", 4.99));
            productDb.Add(new Product("ID28", "Quadrupel", "La Trappe", 4.50));
            productDb.Add(new Product("ID29", "Passat '93 na chasti", "Pernik Tuning", 200.00));
            productDb.Add(new Product("ID30", "Apartament", "Contract City", 120000.99));

            var id = "ID10";
            Console.WriteLine("Product with ID {0}:", id);
            Console.WriteLine(productDb.FindProductById(id));
            Console.WriteLine(new string('-', 20));

            double priceRangeStart = 1000;
            double priceRangeEnd = 100000000;
            Console.WriteLine("Products in range {0} to {1}:", priceRangeStart, priceRangeEnd);
            Console.WriteLine(string.Join("\n", productDb.FindProductsInPriceRange(priceRangeStart, priceRangeEnd)));
            Console.WriteLine(new string('-', 20));

            string title = "Apples";
            Console.WriteLine("Products with title {0}:", title);
            Console.WriteLine(string.Join("\n", productDb.FindProductsByTitle(title)));
            Console.WriteLine(new string('-', 20));

            double price = 1.60;
            Console.WriteLine("Products with title {0} and price {1}:", title, price);
            Console.WriteLine(string.Join("\n", productDb.FindProductsByTitleAndPrice(title, price)));
            Console.WriteLine(new string('-', 20));

            double startPrice = 1.50;
            double endPrice = 1.55;
            Console.WriteLine("Products with title {0} and price between {1} and {2}:", title, startPrice, endPrice);
            Console.WriteLine(string.Join("\n", productDb.FindProductsByTitleAndPriceRange(title, startPrice, endPrice)));
            Console.WriteLine(new string('-', 20));

            string supplier = "Bai Pesho";
            double priceSup = 5.50;
            Console.WriteLine("Products with supplier {0} and price {1}:", supplier, priceSup);
            Console.WriteLine(string.Join("\n", productDb.FindProductsBySupplierAndPrice(supplier, priceSup)));
            Console.WriteLine(new string('-', 20));

            double supStartPrice = 1;
            double supEndPrice = 100;
            Console.WriteLine("Products with supplier {0} and price between {1} and {2}:", supplier, supStartPrice, supEndPrice);
            Console.WriteLine(string.Join("\n", productDb.FindProductsBySupplierAndPriceRange(supplier, supStartPrice, supEndPrice)));
            Console.WriteLine(new string('-', 20));

            var removeId = "ID08";
            Console.WriteLine("Before removal of product with ID {0}", removeId);
            Console.WriteLine(productDb.FindProductById(removeId));
            productDb.RemoveById(removeId);
            Console.WriteLine("After removal of product with ID {0}", removeId);
            Console.WriteLine(productDb.FindProductById(removeId));
        }
    }
}
