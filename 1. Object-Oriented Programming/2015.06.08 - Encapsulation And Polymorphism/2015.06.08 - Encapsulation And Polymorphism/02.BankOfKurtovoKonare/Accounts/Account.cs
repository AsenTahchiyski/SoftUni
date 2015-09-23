namespace BankOfKurtovoKonare.Accounts
{
    using System;
    using BankOfKurtovoKonare.Customers;
    using BankOfKurtovoKonare.Interfaces;

    abstract class Account : IAccount
    {
        private decimal ballance;
        private decimal intRate;

        private decimal minAllowedBallance = -1000000m;
        private decimal maxAllowedInterest = 0.2m;

        public Customer Customer { get; set; }
        public AccountType Type {get; set; }

        public Account(Customer customer, decimal ballance, decimal interest)
        {
            this.Customer = customer;
            this.Ballance = ballance;
            this.InterestRate = interest;
        }

        public decimal Ballance 
        {
            get
            {
                return this.ballance;
            }
            set
            {
                if (value < minAllowedBallance)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Ballance cannot be lower than {0}.", minAllowedBallance));
                }
                this.ballance = value;
            }
        }

        public decimal InterestRate 
        {
            get
            {
                return this.intRate;
            }
            set
            {
                if (value < 0 || value > maxAllowedInterest)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Interest rate cannot be negative or bigger than {0}.", maxAllowedInterest));
                }
                this.intRate = value;
            }
        }

        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount should be positive.");
            }
            this.ballance += amount;
        }

        public virtual decimal CalcInterest(int months)
        {
            return this.ballance * (1 + this.intRate * months);
        }
    }
}
