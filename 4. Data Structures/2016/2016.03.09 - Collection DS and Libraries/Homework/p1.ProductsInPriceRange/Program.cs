using System;
using System.Globalization;
using System.IO;
using System.Threading;
using Wintellect.PowerCollections;

namespace p1.ProductsInPriceRange
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string filePath = "../../pricelist.txt";
            var priceList = new OrderedMultiDictionary<double, string>(true);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();

                while (line != null || !string.IsNullOrEmpty(line))
                {
                    string[] lineData = line.Split('$');
                    double price = double.Parse(lineData[1].Trim());
                    string productName = lineData[0].Trim();

                    priceList.Add(price, productName);
                    line = reader.ReadLine();
                }
            }

            Console.Write("Enter price range start: ");
            double rangeStart = double.Parse(Console.ReadLine());
            Console.Write("Enter price range end: ");
            double rangeEnd = double.Parse(Console.ReadLine());

            var result = priceList.Range(rangeStart, true, rangeEnd, true);
            Console.WriteLine(new string('-', 10));

            foreach (var price in result)
            {
                foreach (var item in price.Value)
                {
                    Console.WriteLine("({0}) {1}", price.Key, item);
                }
            }

            if(result.Count == 0)
            {
                Console.WriteLine("No products in {0} - {1} price range.", rangeStart, rangeEnd);
            }
        }
    }
}
