namespace _3.CollectionOfProducts
{
    using System;

    class Program
    {
        static void Main()
        {
            Database database = new Database();
            database.Add(new Product("B00", "Duvel", "Duvel Moortgat", 4.90m));
            database.Add(new Product("B01", "Vedett", "Duvel Moortgat", 3.90m));
            database.Add(new Product("B02", "Pale Ale", "Glarus", 2.90m));
            database.Add(new Product("B03", "Black Cab", "Fullers", 4.80m));
            database.Add(new Product("B04", "Kriek", "Lindemans", 3.90m));
            database.Add(new Product("B05", "Bock", "Stolichno", 1.90m));
            database.Add(new Product("B06", "Weiss", "Stolichno", 1.80m));
            database.Add(new Product("B07", "Weiss", "Weihenstephan", 3.90m));
            database.Add(new Product("B08", "Weizen", "Shoferhoffer", 3.50m));
            database.Add(new Product("B09", "Brune", "Leffe", 2.50m));
            database.Add(new Product("B10", "Quadrupel", "La Trappe", 4.50m));
            database.Add(new Product("B11", "Wit", "Hoegaarden", 2.50m));
            database.Add(new Product("B12", "Aventinus Icebock", "Schneider-Weisse", 4.90m));
            database.Add(new Product("B13", "Red", "Chimay", 4.60m));
            database.Add(new Product("B14", "Double 24%", "Primator", 2.90m));
            database.Add(new Product("B15", "Blonde", "Bush", 4.20m));
            database.Add(new Product("B16", "Wit", "Blanche de Namur", 4.40m));
            database.Add(new Product("B17", "London Porter", "Fullers", 4.60m));
            database.Add(new Product("B18", "Bock", "La Trappe", 4.40m));
            database.Add(new Product("B19", "Blue", "Chimay", 4.50m));
            database.Add(new Product("B20", "Tripel Hop 2015", "Duvel", 5.40m));
            database.Add(new Product("B21", "Blonde", "Leffe", 2.50m));
            database.Add(new Product("B22", "La Guillotine", "Delirium", 4.80m));
            database.Add(new Product("B23", "Apple", "Lindemans", 3.40m));
            database.Add(new Product("B24", "Gueuze", "Lindemand", 3.70m));
            database.Add(new Product("B25", "Kwak", "Pauwel Kwak", 4.40m));
            database.Add(new Product("B26", "Orval", "Orval", 4.60m));
            database.Add(new Product("B27", "10", "Trappistes Rochefort", 4.80m));
            database.Add(new Product("B28", "8", "Trappistes Rochefort", 4.50m));

            var byTitle = database.FindByTitle("Weiss");
            var allInPriceRange = database.FindAllInPriceRange(4.50m, 6.0m);
            var bySupplierAndPrice = database.FindBySupplierAndPrice("Duvel Moortgat", 4.90m);
            var bySupplierAndPriceRange = database.FindBySupplierAndPriceRange("La Trappe", 4.5m, 5.0m);
            var byTitleAndPrice = database.FindByTitleAndPrice("Bock", 1.90m);
            var byTitleAndPriceRange = database.FindByTitleAndPriceRange("Weiss", 1.8m, 3.0m);

            Console.WriteLine(string.Join(", ", byTitle));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(string.Join(", ", allInPriceRange));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(string.Join(", ", bySupplierAndPrice));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(string.Join(", ", bySupplierAndPriceRange));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(string.Join(", ", byTitleAndPrice));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(string.Join(", ", byTitleAndPriceRange));
            Console.WriteLine(new string('-', 40));
        }
    }
}
