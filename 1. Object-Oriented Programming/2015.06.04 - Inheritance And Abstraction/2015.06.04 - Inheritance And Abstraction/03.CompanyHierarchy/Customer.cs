using System;
using System.Text;

namespace CompanyHierarchy
{
    class Customer : Person, ICustomer
    {
        private decimal NetPurchases { get; set; }

        public Customer(string fName, string lName, string id)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.ID = id;
        }

        public decimal NetPurchaseAmount;

        public void AddPurchase(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Purchase price cannot be negative.");
            }
            this.NetPurchases += price;
            this.NetPurchaseAmount = this.NetPurchases;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("ID {2}: {0} {1}", this.FirstName, this.LastName, this.ID));
            output.AppendLine(string.Format("Net purchase amount = {0}", this.NetPurchaseAmount));
            return output.ToString();
        }
    }
}
