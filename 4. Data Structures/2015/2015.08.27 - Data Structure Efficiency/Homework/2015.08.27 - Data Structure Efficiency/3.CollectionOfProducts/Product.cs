namespace _3.CollectionOfProducts
{
    using System;

    public class Product : IComparable
    {
        public Product(string id, string title, string supplier, decimal price)
        {
            this.ID = id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }
        
        public string ID { get; set; }
       
        public string Title { get; set; }
        
        public string Supplier { get; set; }
        
        public decimal Price { get; set; }


        public int CompareTo(object obj)
        {
            Product other = (Product) (obj);
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2} BGN)", this.Supplier, this.Title, this.Price);
        }
    }
}
