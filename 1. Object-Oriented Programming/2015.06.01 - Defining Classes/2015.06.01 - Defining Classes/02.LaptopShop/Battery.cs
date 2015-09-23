using System;

namespace _02.LaptopShop
{
    class Battery
    {
        // fields
        private string name;
        private double? life;
        private decimal? price;

        // constructors
        public Battery(string batteryName, double? batteryLife, decimal? batteryPrice)
        {
            this.name = batteryName;
            this.price = batteryPrice;
            this.life = batteryLife;
        }
        public Battery(string batteryName, double? batteryLife) : this(batteryName, batteryLife, null) { }
        public Battery(string batteryName) : this(batteryName, null, null) { }
        public Battery() : this(null, null, null) { }

        // properties
        public string Name
        {
            get
            { 
                return this.name; 
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Battery name may not be empty.");
                }
                this.name = value;
            }
        }
        public double? Life 
        {
            get
            {
                return this.life;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery life may not be less than 0.");
                }
                this.life = value;
            }
        }
        public decimal? Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less than 0.");
                }
                this.price = value;
            }
        }
        
    }
}
