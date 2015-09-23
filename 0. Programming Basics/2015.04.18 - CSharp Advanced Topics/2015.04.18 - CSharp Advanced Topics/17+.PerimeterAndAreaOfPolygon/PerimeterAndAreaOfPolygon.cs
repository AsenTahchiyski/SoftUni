// unfinished

using System;
using System.Collections.Generic;

class PerimeterAndAreaOfPolygon
{
    static void Main()
    {
        int points = int.Parse(Console.ReadLine());
        int[,] coordinates = new int[points, 2];
        for (int i = 0; i < points; i++)
        {
            coordinates[i, 0] = int.Parse(Console.ReadLine());
            coordinates[i, 1] = int.Parse(Console.ReadLine());
        }
    }
}
class Point
{
    public static int x;
    public static int y;
}
class Polygon
{
    public static List<int> pointsList;
}
