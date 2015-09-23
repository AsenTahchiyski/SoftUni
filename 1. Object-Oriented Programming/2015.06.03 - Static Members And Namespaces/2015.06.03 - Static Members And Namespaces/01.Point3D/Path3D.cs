using System;
using System.Collections.Generic;

namespace Point3D
{
    class Path3D
    {
        public List<Point3D> Path { get; set; }

        public Path3D(Point3D point)
        {
            this.Path = new List<Point3D>();
            this.Path.Add(point);
        }

        public Path3D(List<Point3D> points)
        {
            this.Path = new List<Point3D>();
            foreach (Point3D point in points)
            {
                this.Path.Add(point);
            }
        }

        public Path3D()
        {
            this.Path = new List<Point3D>();
        }

    }
}
