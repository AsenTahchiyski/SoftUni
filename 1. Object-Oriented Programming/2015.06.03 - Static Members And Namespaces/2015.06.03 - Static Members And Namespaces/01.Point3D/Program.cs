using System;
using System.Collections.Generic;

namespace Point3D
{
    class Program
    {
        static void Main()
        {
            Point3D newPoint = new Point3D(0, 1, 2);
            Console.WriteLine("Point 1: {0}", newPoint.ToString());
            Console.WriteLine(new string('=', 30));

            Point3D center = Point3D.GetCoordinateCenter;
            Console.WriteLine("Start: {0}", center.ToString());
            Console.WriteLine(new string('=', 30));

            Console.WriteLine("Distance between points = {0:F2}", Distance.Calculate(newPoint, center));
            Console.WriteLine(new string('=', 30));

            string filePath = "storage.txt";
            List<Point3D> points = new List<Point3D>();
            points.Add(newPoint);
            points.Add(center);
            Path3D path = new Path3D(points);
            Storage.Save(path, filePath);

            Path3D readPath = Storage.Load("storage.txt");
            int counter = 1;
            foreach (var point in readPath.Path)
            {
                Console.WriteLine("Point {3}: X = {0}, Y = {1}, Z = {2}", point.X, point.Y, point.Z, counter);
                counter++;
            }
            Console.WriteLine();
        }
    }
}
