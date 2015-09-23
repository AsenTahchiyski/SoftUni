package Problem1_Geometry.PlaneShapes;

import Problem1_Geometry.Points.Point2D;

public class Rectangle extends PlaneShape {
    private double width;
    private double height;

    public Rectangle(double width, double height, Point2D vertex) {
        super();
        this.addVertex(vertex);
        this.setWidth(width);
        this.setHeight(height);
    }

    @Override
    public double getArea() {
        return this.getWidth() * this.getHeight();
    }

    @Override
    public double getPerimeter() {
        return 2 * (this.getWidth() + this.getHeight());
    }

    public double getWidth() {
        return this.width;
    }

    public void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException("Width must be a positive number.");
        }

        this.width = width;
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException("Height must be a positive number.");
        }

        this.height = height;
    }
}
