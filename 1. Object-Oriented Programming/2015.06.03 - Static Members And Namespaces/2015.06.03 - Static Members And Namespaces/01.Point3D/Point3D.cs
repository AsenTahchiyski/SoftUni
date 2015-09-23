using System;

namespace Point3D
{
    class Point3D
    {
        private static readonly Point3D center = new Point3D(0, 0, 0);

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("X = {0}, Y = {1}, Z = {2}", this.X, this.Y, this.Z);
        }

        public static Point3D GetCoordinateCenter 
        {
            get
            {
                return center;
            }
        }
    }
}
