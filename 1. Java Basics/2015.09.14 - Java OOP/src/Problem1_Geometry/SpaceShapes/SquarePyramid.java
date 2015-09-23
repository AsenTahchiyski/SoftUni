package Problem1_Geometry.SpaceShapes;

import Problem1_Geometry.Points.Point3D;

public class SquarePyramid extends SpaceShape {
    private double height;
    private double baseWidth;

    public SquarePyramid(Point3D vertex, double height, double baseWidth) {
        super();
        this.addVertex(vertex);
        this.setHeight(height);
        this.setBaseWidth(baseWidth);
    }

    public double getHeight() {
        return this.height;
    }

    private void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException("Height must be positive number.");
        }

        this.height = height;
    }

    public double getBaseWidth() {
        return this.baseWidth;
    }

    private void setBaseWidth(double baseWidth) {
        if (baseWidth <= 0) {
            throw new IllegalArgumentException("Base width must be positive number.");
        }

        this.baseWidth = baseWidth;
    }

    @Override
    public double getArea() {
        double a = this.getBaseWidth();
        double h = this.getHeight();
        double area = a * a + 2 * a * Math.sqrt((a * a / 4) + (h * h));
        return area;
    }

    @Override
    public double getVolume() {
        double a = this.getBaseWidth();
        double h = this.getHeight();
        double volume = a * a * h / 3;
        return volume;
    }
}
