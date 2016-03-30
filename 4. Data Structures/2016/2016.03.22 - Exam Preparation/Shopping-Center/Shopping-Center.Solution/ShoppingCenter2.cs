using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace Shopping_Center
{
    public class ShoppingCenter2
    {
        private Dictionary<string, OrderedBag<Product>> productsByName;
        private Dictionary<string, OrderedBag<Product>> productsByProducer;
        private OrderedDictionary<decimal, OrderedBag<Product>> productsByPrice;
        private Dictionary<string, OrderedBag<Product>> productsByNameAndProducer;

        public ShoppingCenter2()
        {
            this.productsByName = new Dictionary<string, OrderedBag<Product>>();
            this.productsByProducer = new Dictionary<string, OrderedBag<Product>>();
            this.productsByPrice = new OrderedDictionary<decimal, OrderedBag<Product>>();
            this.productsByNameAndProducer = new Dictionary<string, OrderedBag<Product>>();
        }

        public string AddProduct(string name, decimal price, string producer)
        {
            // As a result the command prints “Product added”.
            var product = new Product() { Name = name, Price = price, Producer = producer };

            // add to productsByName
            if (!this.productsByName.ContainsKey(name))
            {
                this.productsByName.Add(name, new OrderedBag<Product>());
            }

            this.productsByName[name].Add(product);

            // add to productsByProducer
            if (!this.productsByProducer.ContainsKey(producer))
            {
                this.productsByProducer.Add(producer, new OrderedBag<Product>());
            }

            this.productsByProducer[producer].Add(product);

            // add to productsByPrice
            if (!this.productsByPrice.ContainsKey(price))
            {
                this.productsByPrice.Add(price, new OrderedBag<Product>());
            }

            this.productsByPrice[price].Add(product);

            // add to productsByNameAndProducer
            string key = MakeNameProducerKey(name, producer);
            if (!this.productsByNameAndProducer.ContainsKey(key))
            {
                this.productsByNameAndProducer.Add(key, new OrderedBag<Product>());
            }

            this.productsByNameAndProducer[key].Add(product);

            return "Product added";
        }

        public string DeleteProducts(string producer)
        {
            // •	DeleteProducts producer – deletes all products matching given producer. As a result the command prints “X products deleted” where X is the number of deleted products or “No products found” if no such products exist.
            if (!this.productsByProducer.ContainsKey(producer))
            {
                return "No products found";
            }

            var deletedProducts = this.productsByProducer[producer];
            if (deletedProducts.Count == 0)
            {
                return "No products found";
            }

            foreach (var prod in deletedProducts)
            {
                this.productsByName[prod.Name].Remove(prod);
                this.productsByPrice[prod.Price].Remove(prod);
                this.productsByNameAndProducer[MakeNameProducerKey(prod.Name, prod.Producer)].Remove(prod);
            }

            this.productsByProducer.Remove(producer);

            return deletedProducts.Count + " products deleted";
        }

        public string DeleteProducts(string name, string producer)
        {
            // •	DeleteProducts name;producer – deletes all products matching given product name and producer. As a result the command prints “X products deleted” where X is the number of deleted products or “No products found” if no such products exist.
            var key = MakeNameProducerKey(name, producer);
            if (!this.productsByNameAndProducer.ContainsKey(key))
            {
                return "No products found";
            }

            var deletedProducts = this.productsByNameAndProducer[key];
            if (deletedProducts.Count == 0)
            {
                return "No products found";
            }

            foreach (Product prod in deletedProducts)
            {
                this.productsByName[prod.Name].Remove(prod);
                this.productsByPrice[prod.Price].Remove(prod);
                this.productsByProducer[prod.Producer].Remove(prod);
            }

            this.productsByNameAndProducer.Remove(key);

            return deletedProducts.Count + " products deleted";
        }

        public string FindProductsByName(string name)
        {
            // •	FindProductsByName name – finds all products by given product name. As a result the command prints a list of products in format {name;producer;price}, ordered by name, producer and price. Print each product on a separate line. If no products exist with the specified name, the command prints “No products found”.
            if (!this.productsByName.ContainsKey(name))
            {
                return "No products found";
            }

            var productsFound = this.productsByName[name];

            if (productsFound.Count == 0)
            {
                return "No products found";
            }

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < productsFound.Count; i++)
            {
                output.Append(productsFound[i]);
                if (i < productsFound.Count - 1)
                {
                    output.AppendLine();
                }
            }

            return output.ToString();
        }

        public string FindProductsByProducer(string producer)
        {
            // •	FindProductsByProducer producer – finds all products by given producer. As a result the command prints a list of products in format {name;producer;price}, ordered by name, producer and price. You should print each product on a single line. If no products exist by the specified producer, the command prints “No products found”.
            if (!this.productsByProducer.ContainsKey(producer))
            {
                return "No products found";
            }

            var productsFound = this.productsByProducer[producer];
            if (productsFound.Count == 0)
            {
                return "No products found";
            }

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < productsFound.Count; i++)
            {
                output.Append(productsFound[i]);
                if (i < productsFound.Count - 1)
                {
                    output.AppendLine();
                }
            }

            return output.ToString();
        }

        public string FindProductsByPriceRange(decimal start, decimal end)
        {
            // •	FindProductsByPriceRange fromPrice;toPrice – finds all products whose price is greater or equal than fromPrice and less or equal than toPrice. As a result the command prints a list of products in format {name;producer;price}, ordered by name, producer and price. You should print each product on a separate line. If no products exist within the specified price range, the command prints “No products found”.

            var output = new StringBuilder();
            var results = new OrderedBag<Product>();
            var ranges = this.productsByPrice.Range(start, true, end, true);
            
            foreach (var range in ranges.Values)
            {
                foreach (var prod in range)
                {
                    results.Add(prod);
                }
            }

            if (results.Count == 0)
            {
                return "No products found";
            }

            for (int i = 0; i < results.Count; i++)
            {
                output.Append(results[i]);
                if (i < results.Count - 1)
                {
                    output.AppendLine();
                }
            }

            return output.ToString();
        }

        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters = parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            switch (method)
            {
                case "AddProduct":
                    var price = decimal.Parse(parameters[1]);
                    return this.AddProduct(parameters[0], price, parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length == 1)
                    {
                        return this.DeleteProducts(parameters[0]);
                    }
                    else
                    {
                        return this.DeleteProducts(parameters[0], parameters[1]);
                    }
                case "FindProductsByName":
                    return FindProductsByName(parameters[0]);
                case "FindProductsByPriceRange":
                    var a = decimal.Parse(parameters[0]);
                    var b = decimal.Parse(parameters[1]);
                    return this.FindProductsByPriceRange(a, b);
                case "FindProductsByProducer":
                    return this.FindProductsByProducer(parameters[0]);
                default:
                    return "Incorrect command";
            }
        }

        private string MakeNameProducerKey(string name, string producer)
        {
            return name + "|" + producer;
        }
    }
}
