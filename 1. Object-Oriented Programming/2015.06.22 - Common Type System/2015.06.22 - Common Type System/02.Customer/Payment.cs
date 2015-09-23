namespace Customer
{
    public class Payment
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Payment(string prodName, decimal price)
        {
            this.ProductName = prodName;
            this.Price = price;
        }
    }
}
