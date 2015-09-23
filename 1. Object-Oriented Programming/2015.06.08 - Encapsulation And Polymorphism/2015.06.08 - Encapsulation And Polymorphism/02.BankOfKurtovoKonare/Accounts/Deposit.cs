namespace BankOfKurtovoKonare.Accounts
{
    using System;
    using BankOfKurtovoKonare.Customers;
    using BankOfKurtovoKonare.Interfaces;

    class Deposit : Account, IDeposit
    {
        private decimal noInterestAmount = 1000m; // must be positive

        public Deposit(Customer customer, decimal ballance, decimal interest) : base(customer, ballance, interest)
        {
            this.Type = AccountType.Deposit;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("You can withdraw positive amounts only.");
            }
            else if (amount > this.Ballance)
            {
                throw new ArgumentOutOfRangeException("Not allowed to withdraw more than your ballance.");
            }
            else
            {
                this.Ballance -= amount;
            }
        }

        public override decimal CalcInterest(int months)
        {
            if (this.Ballance < noInterestAmount)
            {
                return this.Ballance;
            }
            return this.Ballance * (1 + this.InterestRate * months);
        }
    }
}
