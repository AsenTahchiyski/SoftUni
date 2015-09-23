package Problem1_Geometry.PlaneShapes;

import Problem1_Geometry.Interfaces.AreaMeasurable;
import Problem1_Geometry.Interfaces.PerimeterMeasurable;
import Problem1_Geometry.Points.Point;
import Problem1_Geometry.Shape;

public abstract class PlaneShape
        extends Shape
        implements PerimeterMeasurable, AreaMeasurable {
    public PlaneShape() {
        super();
    }

    public abstract double getPerimeter();

    public abstract double getArea();

    @Override
    public String toString() {
        String baseInfo = super.toString();
        StringBuilder output = new StringBuilder();
        output.append(baseInfo + "\r\n");
        output.append("Vertices: ");
        for (Point point : this.getVertices()) {
            output.append(point.getX() + ", " + point.getY() + "; ");
        }

        output.append("\r\n" + "Perimeter: ");
        output.append(this.getPerimeter() + "\r\n");
        output.append("Area: ");
        output.append(this.getArea() + "\r\n");

        return output.toString();
    }
}
