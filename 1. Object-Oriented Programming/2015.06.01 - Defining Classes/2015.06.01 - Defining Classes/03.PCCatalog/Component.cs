using System;

namespace _03.PCCatalog
{
    class Component
    {
        // fields
        private string name;
        private string details;
        private decimal price;

        // properties
        public string Name 
        { 
            get
            {
                return this.name;    
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentNullException("You must specify a component name.");
                }
                this.name = value;
            }
        }
        public string Details { get; set; }
        public decimal Price 
        { 
            get 
            {
                return this.price;
            }
            set
            {
                if (value < 0)
	            {
		            throw new ArgumentOutOfRangeException("Price cannot be negative.");
	            }
                this.price = value;
            }
        }
        // constructors
        public Component(string name, decimal price, string details)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }
        public Component(string name, decimal price) : this(name, price, null) { }
    }
}
