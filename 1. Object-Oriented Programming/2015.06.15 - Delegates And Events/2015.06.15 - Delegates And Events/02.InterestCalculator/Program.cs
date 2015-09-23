namespace InterestCalculator
{
    using System;
    using System.Collections.Generic;

    public delegate decimal CalculateInterest(decimal money, decimal interest, int years);
    class Program
    {
        public static decimal GetSimpleInterest(decimal money, decimal interest, int years)
        {
            decimal result = money * (1 + (interest / 100) * years);
            return result;
        }

        public const int IntrCompoundPerYear = 12;
        public static decimal GetCompoundInterest(decimal money, decimal interest, int years)
        {
            double power = years * IntrCompoundPerYear;
            double argument = (double)(1 + ((interest / 100)) / IntrCompoundPerYear);
            decimal result = (decimal)((double)money * Math.Pow(argument, power));
            return result;
        }
        
        static void Main()
        {
            Console.WriteLine("{0:F4}", new InterestCalculator(500, 5.6m, 10, GetCompoundInterest).GetInterestAmount);
            Console.WriteLine("{0:F4}", new InterestCalculator(2500, 7.2m, 15, GetSimpleInterest).GetInterestAmount);

            //Console.WriteLine(new InterestCalculator(500, 5.6m, 10, GetCompoundInterest));
            //Console.WriteLine(new InterestCalculator(2500, 7.2m, 15, GetSimpleInterest));
        }
    }
}
