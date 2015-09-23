package Problem1_Geometry.SpaceShapes;

import Problem1_Geometry.Points.Point3D;

public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(double radius, Point3D center) {
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
        double area = 4 * this.getRadius() * this.getRadius() * Math.PI;
        return area;
    }

    @Override
    public double getVolume() {
        double r = this.getRadius();
        double volume = 4 * Math.PI * r * r * r / 3;
        return volume;
    }
}
