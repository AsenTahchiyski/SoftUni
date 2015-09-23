namespace FractionCalculator
{
    using System;
    using System.Numerics;

    struct Fraction
    {
        private BigInteger denominator;

        public Fraction(BigInteger a, BigInteger b)
            : this()
        {
            this.Numerator = a;
            this.Denominator = b;
        }

        public BigInteger Numerator { get; set; }

        public BigInteger Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new InvalidOperationException("Denominator cannot be 0.");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Numerator / this.Denominator);
        }
    }
}
