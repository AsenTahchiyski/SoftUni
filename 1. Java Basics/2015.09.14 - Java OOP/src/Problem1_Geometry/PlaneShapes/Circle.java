package Problem1_Geometry.PlaneShapes;

import Problem1_Geometry.Points.Point2D;

public class Circle extends PlaneShape {
    private double radius;

    public Circle(double radius, Point2D center) {
        super();
        this.addVertex(center);
        this.setRadius(radius);
    }

    public double getRadius() {
        return this.radius;
    }

    private void setRadius(double radius) {
        if (radius <= 0) {
            throw new IllegalArgumentException("Radius must be positive number.");
        }

        this.radius = radius;
    }

    @Override
    public double getArea() {
        return Math.PI * this.getRadius() * this.getRadius();
    }

    @Override
    public double getPerimeter() {
        return 2 * this.getRadius() * Math.PI;
    }
}
