using System;

namespace _03.PCCatalog
{
    class Computer
    {
        // fields
        private string name;
        private decimal price;

        // properties
        public string Name 
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentNullException("Please specify a computer name.");
                }
                this.name = value;
            }
        }
        public decimal Price 
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                this.price = value;
            }
        }

        public Component CPU { get; set; }
        public Component Motherboard { get; set; }
        public Component VGA { get; set; }

        // constructors
        public Computer(string name, 
            string cpuName, decimal cpuPrice, string cpuDetails,
            string moboName, decimal moboPrice, string moboDetails,
            string vgaName, decimal vgaPrice, string vgaDetails)
        {
            this.Name = name;
            this.CPU = new Component(cpuName, cpuPrice, cpuDetails);
            this.Motherboard = new Component(moboName, moboPrice, moboDetails);
            this.VGA = new Component(vgaName, vgaPrice, vgaDetails);
            this.Price = cpuPrice + moboPrice + cpuPrice;
        }
        public Computer(string name,
            string cpuName, decimal cpuPrice,
            string moboName, decimal moboPrice,
            string vgaName, decimal vgaPrice)
            : this (name, cpuName, cpuPrice, null, moboName, moboPrice, null,vgaName, vgaPrice, null) { }

        // methods
        public void PrintConfigDetails()
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Computer Details:");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Name: {0}", this.Name);
            Console.WriteLine("CPU: {0}", this.CPU.Name);
            if (!string.IsNullOrEmpty(this.CPU.Details)) Console.WriteLine("CPU Details: {0}", this.CPU.Details);
            Console.WriteLine("Motherboard: {0}", this.Motherboard.Name);
            if (!string.IsNullOrEmpty(this.Motherboard.Details)) Console.WriteLine("Motherboard Details: {0}", this.Motherboard.Details);
            Console.WriteLine("VGA: {0}", this.VGA.Name);
            if (!string.IsNullOrEmpty(this.VGA.Details)) Console.WriteLine("VGA Details: {0}", this.VGA.Details);
            Console.WriteLine("Total Price: {0} BGN", this.Price);
        }
    }
}
