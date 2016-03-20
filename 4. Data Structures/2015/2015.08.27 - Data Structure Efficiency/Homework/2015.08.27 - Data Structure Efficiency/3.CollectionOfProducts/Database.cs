namespace _3.CollectionOfProducts
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Database
    {
        private readonly Dictionary<string, Product> productsById;
        private readonly MultiDictionary<string, Product> productsByTitle; 
        private readonly OrderedMultiDictionary<string, Product> productsByTitleAndPrice; // title|price
        private readonly OrderedMultiDictionary<string, Product> productsBySupplierAndPrice; // supplier|price
        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice;

        public Database()
        {
            this.productsById = new Dictionary<string, Product>();
            this.productsByTitle = new MultiDictionary<string, Product>(true);
            this.productsByTitleAndPrice = new OrderedMultiDictionary<string, Product>(true);
            this.productsBySupplierAndPrice = new OrderedMultiDictionary<string, Product>(true);
            this.productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
        }

        public void Add(Product product)
        {
            string id = product.ID;
            string title = product.Title;
            string supplier = product.Supplier;
            decimal price = product.Price;
            
            this.productsById.Add(id, product);
            this.productsByTitle.Add(title, product);
            this.productsByTitleAndPrice.Add(title + '|' + price, product);
            this.productsBySupplierAndPrice.Add(supplier + '|' + price, product);
            this.productsByPrice.Add(price, product);
        }

        public void AddRange(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                this.Add(product);
            }
        }

        public void RemoveById(string id)
        {
            Product product = this.productsById[id];
            string title = product.Title;
            string supplier = product.Supplier;
            decimal price = product.Price;

            this.productsById.Remove(id);
            this.productsByTitle[title].Remove(product);
            this.productsByTitleAndPrice[title + '|' + price].Remove(product);
            this.productsBySupplierAndPrice[supplier + '|' + price].Remove(product);
            this.productsByPrice[price].Remove(product);
        }

        public IEnumerable<Product> FindAllInPriceRange(decimal min, decimal max)
        {
            return this.productsByPrice.Range(min, true, max, true).Values;
        }

        public IEnumerable<Product> FindByTitle(string title)
        {
            return this.productsByTitle[title];
        }

        public IEnumerable<Product> FindByTitleAndPrice(string title, decimal price)
        {
            return this.productsByTitleAndPrice[title + '|' + price];
        } 

        public IEnumerable<Product> FindByTitleAndPriceRange(string title, decimal min, decimal max)
        {
            return this.productsByTitleAndPrice.Range(title + '|' + min, true, title + '|' + max, true).Values;
        }

        public IEnumerable<Product> FindBySupplierAndPrice(string supplier, decimal price)
        {
            return this.productsBySupplierAndPrice[supplier + '|' + price];
        }

        public IEnumerable<Product> FindBySupplierAndPriceRange(string supplier, decimal min, decimal max)
        {
            return this.productsBySupplierAndPrice.Range(supplier + '|' + min, true, supplier + '|' + max, true).Values;
        }
    }
}
