package Problem1_Geometry;

import Problem1_Geometry.Points.Point;
import java.util.ArrayList;
import java.util.List;

public abstract class Shape {
    private List<Point> vertices;

    public Shape() {
        this.vertices = new ArrayList<>();
    }

    public Iterable<Point> getVertices() {
        return this.vertices;
    }

    protected void addVertex(Point vertex) {
        this.vertices.add(vertex);
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append("Shape type: ");
        output.append(this.getClass().getSimpleName());

        return output.toString();
    }
}
