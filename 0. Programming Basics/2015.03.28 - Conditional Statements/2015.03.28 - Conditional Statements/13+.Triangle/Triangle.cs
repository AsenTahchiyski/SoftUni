using System;
class Triangle
{
    static void Main()
    {
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());
        double ab = Math.Sqrt((bX - aX) * (bX - aX) + (bY - aY) * (bY - aY));
        double bc = Math.Sqrt((cX - bX) * (cX - bX) + (cY - bY) * (cY - bY));
        double ca = Math.Sqrt((aX - cX) * (aX - cX) + (aY - cY) * (aY - cY));
        if (ab + bc > ca && bc + ca > ab && ab + ca > bc)
        {
            double perimeter = (ab + bc + ca) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - ab) * (perimeter - bc) * (perimeter - ca));
            Console.WriteLine("Yes\n{0:F2}", area);
        }
        else
        {
            Console.WriteLine("No\n{0:F2}", ab);
        }
    }
}
