using System;

namespace CompanyHierarchy
{
    class Sale
    {
        public string ProductName
        {
            get
            {
                return this.ProductName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Product name cannot be empty.");
                }
                this.ProductName = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.Date;
            }
            set
            {
                DateTime dateIn;
                if (!DateTime.TryParse(value.ToString(), out dateIn))
                {
                    throw new FormatException("Invalid date format.");
                }
                this.Date = dateIn;
            }
        }

        public decimal Price
        {
            get
            {
                return this.Price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                this.Price = value;
            }
        }
    }
}
