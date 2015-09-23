package Problem1_Geometry.SpaceShapes;

import Problem1_Geometry.Points.Point3D;

public class Cuboid extends SpaceShape {
    private double width;
    private double height;
    private double depth;

    public Cuboid(double width, double height, double depth, Point3D vertex) {
        super();
        this.addVertex(vertex);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
    }

    public double getWidth() {
        return this.width;
    }

    private void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException("Width must be positive number.");
        }

        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    private void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException("Height must be positive number.");
        }

        this.height = height;
    }

    public double getDepth() {
        return depth;
    }

    private void setDepth(double depth) {
        if (depth <= 0) {
            throw new IllegalArgumentException("Depth must be positive number.");
        }

        this.depth = depth;
    }

    @Override
    public double getArea() {
        double h = this.getHeight();
        double d = this.getDepth();
        double w = this.getWidth();
        double area = 2 * (h * d + d * w + h * w);
        return area;
    }

    @Override
    public double getVolume() {
        double volume = this.getWidth() * this.getDepth() * this.getHeight();
        return volume;
    }
}
