namespace InterestCalculator
{
    using System;
    using System.Collections.Generic;

    public class InterestCalculator
    {
        private decimal sum;
        private decimal interest;
        private int years;

        public decimal MoneyAmount 
        {
            get { return this.sum; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Amount of money cannot be negative.");
                }
                this.sum = value;
            }
        }

        public decimal Interest 
        {
            get { return this.interest; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest cannot be negative.");
                }
                this.interest = value;
            }
        }

        public int Years 
        {
            get { return this.years; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of years cannot be negative.");
                }
                this.years = value;
            }
        }

        public CalculateInterest InterestCalcMethod { get; set; }

        public decimal GetInterestAmount { get; set; }

        public InterestCalculator(decimal money, decimal interest, int years, CalculateInterest dlg)
        {
            this.MoneyAmount = money;
            this.Interest = interest;
            this.Years = years;
            this.InterestCalcMethod = dlg;
            this.GetInterestAmount = dlg(money, interest, years);
        }

        //public override string ToString()
        //{
        //    return string.Format("{0:F4}", this.CalculateInterest(this.MoneyAmount, this.Interest, this.Years));
        //}
    }
}
