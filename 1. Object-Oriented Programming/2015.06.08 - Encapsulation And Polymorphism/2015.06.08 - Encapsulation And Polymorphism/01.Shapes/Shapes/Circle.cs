using System;

namespace _01.Shapes
{
    class Circle : IShape
    {
        private double radius;

        public Circle(double rad)
        {
            this.Radius = rad;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * this.radius;
        }

        public double CalculateArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public double Radius 
        {
            get
            {
                return this.radius;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid radius.");
                }
                this.radius = value;
            }
        }
    }
}
