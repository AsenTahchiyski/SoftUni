using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace p3.CollectionOfProducts
{
    public class Database
    {
        private Dictionary<string, Product> productsById;
        private Dictionary<string, OrderedBag<Product>> productsByTitle;
        private OrderedDictionary<double, OrderedBag<Product>> productsByPriceRange;
        private OrderedDictionary<string, OrderedDictionary<double, OrderedBag<Product>>> productsByTitleAndPriceRange;
        private OrderedDictionary<string, OrderedDictionary<double, OrderedBag<Product>>> productsBySupplierAndPriceRange;

        // id - product
        // prod by price range
        // prod by title
        // prod by title + price
        // prod by title + price range
        // prod by supplier + price
        // prod by supplier + price range
        // remove by id - true/false
        // products are always sorted by id

        public Database()
        {
            productsById = new Dictionary<string, Product>();
            productsByTitle = new Dictionary<string, OrderedBag<Product>>();
            productsByPriceRange = new OrderedDictionary<double, OrderedBag<Product>>();
            productsByTitleAndPriceRange = new OrderedDictionary<string, OrderedDictionary<double, OrderedBag<Product>>>();
            productsBySupplierAndPriceRange = new OrderedDictionary<string, OrderedDictionary<double, OrderedBag<Product>>>();
        }

        public bool Add(Product product)
        {
            try
            {
                // add to productsById
                this.productsById.Add(product.Id, product);

                // add to productsByTitle
                if (!this.productsByTitle.ContainsKey(product.Title))
                {
                    this.productsByTitle.Add(product.Title, new OrderedBag<Product>());
                }

                this.productsByTitle[product.Title].Add(product);

                // add to productsByPriceRange
                if (!this.productsByPriceRange.ContainsKey(product.Price))
                {
                    this.productsByPriceRange.Add(product.Price, new OrderedBag<Product>());
                }

                this.productsByPriceRange[product.Price].Add(product);

                // add to productsByTitleAndPriceRange
                if (!this.productsByTitleAndPriceRange.ContainsKey(product.Title))
                {
                    this.productsByTitleAndPriceRange.Add(product.Title, new OrderedDictionary<double, OrderedBag<Product>>());
                    this.productsByTitleAndPriceRange[product.Title].Add(product.Price, new OrderedBag<Product>());
                    this.productsByTitleAndPriceRange[product.Title][product.Price].Add(product);
                }
                else if(!this.productsByTitleAndPriceRange[product.Title].ContainsKey(product.Price))
                {
                    this.productsByTitleAndPriceRange[product.Title].Add(product.Price, new OrderedBag<Product>());
                    this.productsByTitleAndPriceRange[product.Title][product.Price].Add(product);
                }
                else if (!this.productsByTitleAndPriceRange[product.Title][product.Price].Contains(product))
                {
                    this.productsByTitleAndPriceRange[product.Title][product.Price].Add(product);
                }

                // add to productsBySupplierAndPriceRange
                if (!this.productsBySupplierAndPriceRange.ContainsKey(product.Supplier))
                {
                    this.productsBySupplierAndPriceRange.Add(product.Supplier, new OrderedDictionary<double, OrderedBag<Product>>());
                    this.productsBySupplierAndPriceRange[product.Supplier].Add(product.Price, new OrderedBag<Product>());
                    this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Add(product);
                }
                else if (!this.productsBySupplierAndPriceRange[product.Supplier].ContainsKey(product.Price))
                {
                    this.productsBySupplierAndPriceRange[product.Supplier].Add(product.Price, new OrderedBag<Product>());
                    this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Add(product);
                }
                else if (!this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Contains(product))
                {
                    this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Add(product);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool RemoveById(string id)
        {
            if (!this.productsById.ContainsKey(id))
            {
                return false;
            }

            Product product = this.productsById[id];
            bool inProductsByTitle = this.productsByTitle.ContainsKey(product.Title) && 
                                    this.productsByTitle[product.Title].Contains(product);
            bool inProductsByPriceRange = this.productsByPriceRange.ContainsKey(product.Price) &&
                                    this.productsByPriceRange[product.Price].Contains(product);
            bool inProductsByTitleAndPriceRange = this.productsByTitleAndPriceRange.ContainsKey(product.Title) &&
                                                this.productsByTitleAndPriceRange[product.Title].ContainsKey(product.Price) &&
                                                this.productsByTitleAndPriceRange[product.Title][product.Price].Contains(product);
            bool inProductsBySupplierAndPriceRange = this.productsBySupplierAndPriceRange.ContainsKey(product.Supplier) &&
                                                this.productsBySupplierAndPriceRange[product.Supplier].ContainsKey(product.Price) &&
                                                this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Contains(product);

            if (inProductsByTitle && inProductsByPriceRange &&
                inProductsByTitleAndPriceRange && inProductsBySupplierAndPriceRange)
            {
                this.productsById.Remove(id);
                this.productsByTitle[product.Title].Remove(product);
                this.productsByPriceRange[product.Price].Remove(product);
                this.productsByTitleAndPriceRange[product.Title][product.Price].Remove(product);
                this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Remove(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product FindProductById(string id)
        {
            Product result = null;
            if (this.productsById.ContainsKey(id))
            {
                result = this.productsById[id];
            }

            return result;
        }

        public IEnumerable<Product> FindProductsInPriceRange(double start, double end)
        {
            try
            {
                var all = this.productsByPriceRange.Range(start, true, end, true).Values;
                var result = new List<Product>();
                foreach (var set in all)
                {
                    result.AddRange(set);
                }

                return result;
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            try
            {
                return this.productsByTitle[title];
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, double price)
        {
            try
            {
                return this.productsByTitleAndPriceRange[title][price];
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, double start, double end)
        {
            try
            {
                var all = this.productsByTitleAndPriceRange[title].Range(start, true, end, true);
                var result = new List<Product>();
                foreach (var set in all.Values)
                {
                    result.AddRange(set);
                }

                return result;
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, double price)
        {
            try
            {
                return this.productsBySupplierAndPriceRange[supplier][price];
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> FindProductsBySupplierAndPriceRange(string supplier, double start, double end)
        {
            try
            {
                var all = this.productsBySupplierAndPriceRange[supplier].Range(start, true, end, true);
                var result = new List<Product>();
                foreach (var set in all.Values)
                {
                    result.AddRange(set);
                }

                return result;
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }
    }
}
