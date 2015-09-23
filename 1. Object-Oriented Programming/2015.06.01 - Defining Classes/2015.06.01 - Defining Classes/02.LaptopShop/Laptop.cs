using System;
using System.Text;

namespace _02.LaptopShop
{
    class Laptop
    {
        // fields
        private string model;
        private decimal price;
        private string cpu;
        private string maker;
        private int? ram;
        private string vga;
        private string hdd;
        private string screen;
        private double batteryLife;
        private string batteryName;
        private Battery battery;
        // properties
        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("You must enter a model.");
                }
                else this.model = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid price.");
                }
                this.price = value;
            }
        }
        public string Maker
        {
            get { return this.maker; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Maker may be null but not empty.");
                }
                this.maker = value;
            }
        }
        public string CPU
        {
            get { return this.cpu; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("CPU may be null but not empty.");
                }
                this.cpu = value;
            }
        }
        public int? RAM
        {
            get { return this.ram; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid RAM value.");
                }
                this.ram = value;
            }
        }
        public string VGA
        {
            get { return this.vga; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("VGA may be null but not empty.");
                }
                this.vga = value;
            }
        }
        public string HDD
        {
            get { return this.hdd; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("HDD may be null but not empty.");
                }
                this.hdd = value;
            }
        }
        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Screen may be null but not empty.");
                }
                this.screen = value;
            }
        }
        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = new Battery(this.batteryName, this.batteryLife);
            }
        }

        // constructors
        public Laptop(string model, decimal price) : this (model, price, null, null, null, null, null, null, null, null) { }
        public Laptop(string model, decimal price, string maker, string cpu, int? ram, string vga, string hdd, string screen, string batteryName, double? batteryLife)
        {
            this.Model = model;
            this.Price = price;
            this.Maker = maker;
            this.CPU = cpu;
            this.RAM = ram;
            this.VGA = vga;
            this.HDD = hdd;
            this.Screen = screen;
            this.battery = new Battery(batteryName, batteryLife);
        }
        // method
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(new string('=', 30));
            output.AppendLine("Laptop Description");
            output.AppendLine(new string('=', 30));
            output.AppendLine(string.Format("Model: {0}", this.model));
            if(this.maker != null) output.AppendLine(string.Format("Maker: {0}", this.maker));
            if (this.cpu != null) output.AppendLine(string.Format("CPU: {0}", this.cpu));
            if (this.ram > 0) output.AppendLine(string.Format("RAM: {0} GB", this.ram));
            if (this.vga != null) output.AppendLine(string.Format("VGA: {0}", this.vga));
            if (this.hdd != null) output.AppendLine(string.Format("HDD: {0}", this.hdd));
            if (this.screen != null) output.AppendLine(string.Format("Screen: {0}", this.screen));
            if (this.battery.Name != null) output.AppendLine(string.Format("Battery: {0}", this.battery.Name));
            if (this.battery.Life >= 0) output.AppendLine(string.Format("Battery Life: {0}", this.battery.Life));
            output.AppendLine(string.Format("Price: {0} lv", this.price));
            return output.ToString();
        }
    }
}
