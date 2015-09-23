namespace CohesionAndCoupling
{
    using System;

    public static class Utilities2D
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static double CalcRectangleDiagonal(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be positive.");
            }

            double distance = CalcDistance2D(0, 0, width, height);
            return distance;
        }
    }
}
