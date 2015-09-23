namespace CohesionAndCoupling
{
    using System;

    public static class Utilities3D
    {
        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
            return distance;
        }

        public static double CalculateVolume(double width, double height, double depth)
        {
            ValidateValuesArePositive(width, height, depth);
            double volume = width * height * depth;
            return volume;
        }

        public static double CalculateCubeDiagonal(double width, double height, double depth)
        {
            ValidateValuesArePositive(width, height, depth);
            double distance = CalculateDistance3D(0, 0, 0, width, height, depth);
            return distance;
        }

        private static void ValidateValuesArePositive(double width, double height, double depth)
        {
            if (width <= 0 || height <= 0 || depth <= 0)
            {
                throw new ArgumentException("Width, height and depth must be positive.");
            }
        }
    }
}
