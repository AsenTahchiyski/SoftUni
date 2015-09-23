package Problem1_Geometry.SpaceShapes;

import Problem1_Geometry.Interfaces.AreaMeasurable;
import Problem1_Geometry.Interfaces.VolumeMeasurable;
import Problem1_Geometry.Points.Point;
import Problem1_Geometry.Shape;

import java.text.Format;

public abstract class SpaceShape
        extends Shape
        implements AreaMeasurable, VolumeMeasurable{
    public SpaceShape() {
        super();
    }

    @Override
    public String toString() {
        String baseInfo = super.toString();
        StringBuilder output = new StringBuilder();
        output.append(baseInfo + "\r\n");
        output.append("Vertices: ");
        for (Point point : this.getVertices()) {
            output.append(point.getX() + ", " + point.getY() + ", " + point.getZ() + "\r\n");
        }

        output.append("Area: ");
        output.append(this.getArea() + "\r\n");
        output.append("Volume: ");
        output.append(this.getVolume() + "\r\n");

        return output.toString();
    }
}
