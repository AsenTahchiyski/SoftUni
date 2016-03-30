using System;

namespace p3.CollectionOfProducts
{
    public class Product : IComparable<Product>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Supplier { get; set; }
        public double Price { get; set; }

        public Product(string id, string title, string supplier, double price)
        {
            this.Id = id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return string.Format("({0}) {1} by {2}: {3:f2} BGN", this.Id, this.Title, this.Supplier, this.Price);
        }
    }
}
