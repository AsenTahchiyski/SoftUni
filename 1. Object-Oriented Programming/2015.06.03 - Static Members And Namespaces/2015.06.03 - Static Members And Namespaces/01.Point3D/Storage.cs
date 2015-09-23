using System;
using System.IO;
using System.Collections.Generic;

namespace Point3D
{
    static class Storage
    {
        public static void Save(Path3D path, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var point in path.Path)
                {
                    writer.WriteLine(string.Format("{0} {1} {2}", point.X, point.Y, point.Z));
                }
            }
        }

        public static Path3D Load(string filePath)
        {
            List<Point3D> points = new List<Point3D>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] coordinates = line.Split(' ');
                    if (coordinates.Length != 3)
                    {
                        reader.Close();
                        throw new InvalidDataException("Input file contains wrong point coordinates data.");
                    }
                    double x = double.Parse(coordinates[0]);
                    double y = double.Parse(coordinates[1]);
                    double z = double.Parse(coordinates[2]);
                    Point3D point = new Point3D(x, y, z);
                    points.Add(point);
                }
            }
            Path3D path = new Path3D(points);
            return path;
        }
    }
}
