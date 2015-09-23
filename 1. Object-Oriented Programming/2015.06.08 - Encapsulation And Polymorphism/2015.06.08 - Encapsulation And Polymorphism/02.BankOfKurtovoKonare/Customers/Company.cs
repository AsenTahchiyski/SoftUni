namespace BankOfKurtovoKonare.Customers
{
    using System;
    using BankOfKurtovoKonare.Interfaces;
    
    public class Company : Customer, ICompany
    {
        private string name;
        private string mol; // Материално Отговорно Лице (MRP - Materially Responsible Person)
        private string bulstat;

        public Company(string address, string phone, string name, string mol, string bulstat) : base(address, phone)
        {
            this.Name = name;
            this.MOL = mol;
            this.Bulstat = bulstat;
            this.Type = CustomerType.Company;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Company name cannot be empty.");
                }
                this.name = value;
            }
        }

        public string MOL
        {
            get
            {
                return this.mol;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("MOL (MRP) name cannot be empty.");
                }
                this.mol = value;
            }
        }

        public string Bulstat
        {
            get
            {
                return this.bulstat;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Bulstat code cannot be empty.");
                }
                this.bulstat = value;
            }
        }
    }
}
