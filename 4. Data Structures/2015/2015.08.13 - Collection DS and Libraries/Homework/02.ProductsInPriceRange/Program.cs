namespace _02.ProductsInPriceRange
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using Wintellect.PowerCollections;

    class Program
    {
        private const int PrintFirstNProducts = 20;

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string filePath = "../../pricelist.txt";
            var priceList = new OrderedMultiDictionary<double, string>(true);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] productInfo = line.Split('$');
                    string productName = productInfo[0].Trim();
                    string preparePriceFormat = productInfo[1].Trim();
                    preparePriceFormat = preparePriceFormat.Replace(",", ".");
                    double productPrice = double.Parse(preparePriceFormat);

                    priceList.Add(productPrice, productName);

                    line = reader.ReadLine();
                }
            }

            Console.Write("Enter range start (xx.xx): ");
            double rangeStart = double.Parse(Console.ReadLine());
            Console.Write("Enter range end (xx.xx): ");
            double rangeEnd = double.Parse(Console.ReadLine());

            Console.WriteLine("First 20 products in theis range are as follows:");
            var productsInRange = priceList.Range(rangeStart, true, rangeEnd, true);

            int counter = 0;

            foreach (var priceProducts in productsInRange)
            {
                foreach (var product in priceProducts.Value)
                {
                    Console.WriteLine("{0} (${1})", product, priceProducts.Key);
                    counter++;
                    if (counter == PrintFirstNProducts)
                    {
                        return;
                    }
                }
            }
        }
    }
}
