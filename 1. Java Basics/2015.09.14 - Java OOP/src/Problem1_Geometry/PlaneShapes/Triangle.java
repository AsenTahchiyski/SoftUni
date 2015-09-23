package Problem1_Geometry.PlaneShapes;

import Problem1_Geometry.Points.Point2D;

public class Triangle extends PlaneShape {
    private Point2D vertexA;
    private Point2D vertexB;
    private Point2D vertexC;

    public Triangle(Point2D vertexA, Point2D vertexB, Point2D vertexC) {
        super();
        this.addVertex(vertexA);
        this.addVertex(vertexB);
        this.addVertex(vertexC);

        this.vertexA = vertexA;
        this.vertexB = vertexB;
        this.vertexC = vertexC;
    }

    @Override
    public double getArea() {
        double p = this.getPerimeter();
        double a = this.getSideAB();
        double b = this.getSideBC();
        double c = this.getSideAC();
        double area = Math.sqrt(p * (p - a) * (p - b) * (p - c));
        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = this.getSideAB() + this.getSideBC() + this.getSideAC();
        return perimeter;
    }

    public double getSideAB() {
        double side = Math.sqrt(
                (this.vertexA.getX() - this.vertexB.getX() * (this.vertexA.getX() - this.vertexB.getX()) +
                (this.vertexA.getY() - this.vertexB.getY() * (this.vertexA.getY() - this.vertexB.getY()))));
        return side;
    }

    public double getSideBC() {
        double side = Math.sqrt(
                (this.vertexB.getX() - this.vertexC.getX() * (this.vertexB.getX() - this.vertexC.getX()) +
                (this.vertexB.getY() - this.vertexC.getY() * (this.vertexB.getY() - this.vertexC.getY()))));
        return side;
    }

    public double getSideAC() {
        double side = Math.sqrt(
                (this.vertexA.getX() - this.vertexC.getX() * (this.vertexA.getX() - this.vertexC.getX()) +
                (this.vertexA.getY() - this.vertexC.getY() * (this.vertexA.getY() - this.vertexC.getY()))));
        return side;
    }
}
