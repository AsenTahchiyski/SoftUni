namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine("I am a circle with radius {2}. " + "\nMy perimeter is {0:f2}. My surface is {1:f2}.", circle.CalculatePerimeter(), circle.CalculateSurface(), circle.Radius);

            Console.WriteLine(new string('-', 40));

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle with width {2} and height {3}. " + "\nMy perimeter is {0:f2}. My surface is {1:f2}.", rect.CalculatePerimeter(), rect.CalculateSurface(), rect.Width, rect.Height);

            Console.WriteLine(new string('-', 40));
        }
    }
}
