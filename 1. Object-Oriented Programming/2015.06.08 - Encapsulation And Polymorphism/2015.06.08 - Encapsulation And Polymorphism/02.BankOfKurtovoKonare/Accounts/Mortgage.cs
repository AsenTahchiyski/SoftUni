namespace BankOfKurtovoKonare.Accounts
{
    using System;
    using BankOfKurtovoKonare.Interfaces;
    using BankOfKurtovoKonare.Customers;

    class Mortgage : Account, IMortgage
    {
        private readonly int halfInterestMonthsCompany = 12;
        private readonly int halfInterestMonthsPerson = 6;

        public Mortgage(Customer customer, decimal ballance, decimal interest)
            : base(customer, ballance, interest)
        {
            this.Type = AccountType.Mortgage;
        }

        public override decimal CalcInterest(int months)
        {
            if (this.Customer.Type == CustomerType.Person)
            {
                if (months <= halfInterestMonthsPerson)
                {
                    return this.Ballance * (1 + (this.InterestRate / 2) * months);
                }
                else return this.Ballance * (1 + this.InterestRate * (months - halfInterestMonthsPerson)) +
                    this.Ballance * (1 + (this.InterestRate / 2) * halfInterestMonthsPerson);
            }
            else if (this.Customer.Type == CustomerType.Company)
            {
                if (months <= halfInterestMonthsCompany)
                {
                    return this.Ballance * (1 + (this.InterestRate / 2) * months);
                }
                else return this.Ballance * (1 + this.InterestRate * (months - halfInterestMonthsCompany)) +
                    this.Ballance * (1 + (this.InterestRate / 2) * halfInterestMonthsCompany);
            }
            else throw new ArgumentOutOfRangeException("Unknown customer type.");
        }
    }
}
