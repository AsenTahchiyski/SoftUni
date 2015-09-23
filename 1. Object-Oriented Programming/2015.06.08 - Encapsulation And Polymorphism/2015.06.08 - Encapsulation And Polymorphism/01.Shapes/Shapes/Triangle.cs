using System;

namespace _01.Shapes
{
    class Triangle : BasicShape
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.A = sideA;
            this.B = sideB;
            this.C = sideC;
        }
        
        public override double CalculateArea()
        {
            double p = this.a + this.b + this.c;
            return Math.Sqrt(p * (p - this.a) * (p - this.b) * (p - this.c));
        }

        public override double CalculatePerimeter()
        {
            return this.a + this.b + this.c;
        }

        public double A
        {
            get
            {
                return this.a;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Side should be bigger than 0.");
                }
                this.a = value;
            }
        }

        public double B
        {
            get
            {
                return this.b;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Side should be bigger than 0.");
                }
                this.b = value;
            }
        }

        public double C
        {
            get
            {
                return this.c;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Side should be bigger than 0.");
                }
                this.c = value;
            }
        }
    }
}
