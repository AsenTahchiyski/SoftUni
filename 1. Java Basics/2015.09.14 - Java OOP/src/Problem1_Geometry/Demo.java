package Problem1_Geometry;

import Problem1_Geometry.PlaneShapes.Circle;
import Problem1_Geometry.PlaneShapes.PlaneShape;
import Problem1_Geometry.PlaneShapes.Rectangle;
import Problem1_Geometry.PlaneShapes.Triangle;
import Problem1_Geometry.Points.Point2D;
import Problem1_Geometry.Points.Point3D;
import Problem1_Geometry.SpaceShapes.Cuboid;
import Problem1_Geometry.SpaceShapes.SpaceShape;
import Problem1_Geometry.SpaceShapes.Sphere;
import Problem1_Geometry.SpaceShapes.SquarePyramid;
import java.util.Arrays;
import java.util.Comparator;

public class Demo {
    public static void main(String[] args) {
        Triangle triangle = new Triangle(
                new Point2D(1.0, 2.0),
                new Point2D(2.0, 3.0),
                new Point2D(1.0, 3.0));
        Rectangle rectangle = new Rectangle(10.0, 15.0, new Point2D(2, 2));
        Circle circle = new Circle(17, new Point2D(3.3, 4.4));
        SquarePyramid pyramid = new SquarePyramid(new Point3D(4.4, 5.5, 6.6), 5.5 ,6.6);
        Cuboid cuboid = new Cuboid(13, 5, 3, new Point3D(11, 12, 13));
        Sphere sphere = new Sphere(9, new Point3D(22, 23, 25));

        Shape[] shapes = new Shape[6];
        shapes[0] = triangle;
        shapes[1] = rectangle;
        shapes[2] = circle;
        shapes[3] = pyramid;
        shapes[4] = cuboid;
        shapes[5] = sphere;

        for (Shape shape : shapes) {
            System.out.println(shape);
        }

        System.out.println(">> SpaceShapes with volume over 40.0:");
        Arrays.asList(shapes).stream()
            .filter(s -> s instanceof SpaceShape)
            .filter(x -> ((SpaceShape) x).getVolume() > 40.0)
            .forEach(System.out::println);

        System.out.println(">> PlaneShapes sorted by perimeter:");
        Arrays.asList(shapes).stream()
                .filter(s -> s instanceof PlaneShape)
                .sorted(new Comparator<Shape>() {
                    @Override
                    public int compare(Shape o1, Shape o2) {
                        return (int)(((PlaneShape) o1).getPerimeter() - ((PlaneShape) o2).getPerimeter());
                    }
                })
                .forEach(System.out::println);
    }
}
