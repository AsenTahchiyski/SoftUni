namespace BankOfKurtovoKonare.Accounts
{
    using System;
    using BankOfKurtovoKonare.Interfaces;
    using BankOfKurtovoKonare.Customers;

    class Loan : Account, ILoan
    {
        private int noInterestMonthsIndiv = 3;
        private int noInterestMonthsCompany = 2;

        public Loan(Customer customer, decimal ballance, decimal interest)
            : base(customer, ballance, interest)
        {
            this.Type = AccountType.Loan;
        }

        public override decimal CalcInterest(int months)
        {
            if (this.Customer.Type == CustomerType.Person)
            {
                if (months <= noInterestMonthsIndiv)
                {
                    return this.Ballance;
                }
                return this.Ballance * (1 + this.InterestRate * (months - noInterestMonthsIndiv));
            }
            else if (this.Customer.Type == CustomerType.Company)
            {
                if (months <= noInterestMonthsCompany)
                {
                    return this.Ballance;
                }
                return this.Ballance * (1 + this.InterestRate * (months - noInterestMonthsCompany));
            }
            else throw new ArgumentOutOfRangeException("Unknown customer type.");
        }
    }
}
