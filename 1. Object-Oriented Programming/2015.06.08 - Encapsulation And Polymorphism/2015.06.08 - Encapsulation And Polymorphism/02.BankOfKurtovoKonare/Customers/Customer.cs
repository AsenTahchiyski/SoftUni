namespace BankOfKurtovoKonare.Customers
{
    using System;
    using BankOfKurtovoKonare.Interfaces;

    abstract public class Customer : ICustomer
    {
        private string address;
        private string phone;

        public CustomerType Type { get; set; }

        public Customer(string address, string phone)
        {
            this.Address = address;
            this.Phone = phone;
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Address cannot be empty.");
                }
                this.address = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Phone number cannot be empty.");
                }
                this.phone = value;
            }
        }
    }
}
