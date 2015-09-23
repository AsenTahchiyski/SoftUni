namespace _01.Shapes
{
    abstract class BasicShape : IShape
    {
        //private double width;
        //private double height;

        abstract public double CalculateArea();
        abstract public double CalculatePerimeter();
    }
}
