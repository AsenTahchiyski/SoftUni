using System;

namespace _01.Shapes
{
    class Rectangle : BasicShape
    {
        private double a;
        private double b;
        
        public override double CalculateArea()
        {
            return this.a * this.b;
        }

        public override double CalculatePerimeter()
        {
            return 2 * this.a + 2 * this.b;
        }

        public Rectangle(double sideA, double sideB)
        {
            this.A = sideA;
            this.B = sideB;
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
    }
}
