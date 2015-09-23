using System;

namespace _01.Shapes
{
    class Program
    {
        static void Main()
        {
            Triangle triangle = new Triangle(1.1, 2.2, 3.3);
            Rectangle rectangle = new Rectangle(2.2, 3.2);
            Circle circle = new Circle(2.2);

            IShape[] figures = { triangle, rectangle, circle };
            foreach (var figure in figures)
            {
                Console.WriteLine("Area of this {0} = {1:0.##}", figure.GetType().Name, figure.CalculateArea());
                Console.WriteLine("Perimeter of this {0} = {1:0.##}", figure.GetType().Name, figure.CalculatePerimeter());
                Console.WriteLine(new string('=', 40));
            }
        }
    }
}
