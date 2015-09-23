import java.awt.*;
import java.io.*;
import java.util.Scanner;

import org.apache.batik.svggen.SVGGraphics2D;
import org.apache.batik.dom.GenericDOMImplementation;

import org.w3c.dom.Document;
import org.w3c.dom.DOMImplementation;

public class PaintAHouse {
    public static void main(String[] args) throws IOException {

        // Get a DOMImplementation.
        DOMImplementation domImpl =
                GenericDOMImplementation.getDOMImplementation();

        // Create an instance of org.w3c.dom.Document.
        String svgNS = "http://www.w3.org/2000/svg";
        Document document = domImpl.createDocument(svgNS, "svg", null);

        // Create an instance of the SVG Generator.
        SVGGraphics2D renderer = new SVGGraphics2D(document);

        // Render objects
        renderer.setColor(Color.lightGray);
        renderer.fillRect(200, 400, 200, 200);
        renderer.fillRect(500, 400, 100, 200);
        renderer.fill(new Polygon( // the triangle
                new int[]{200, 600, 400},
                new int[]{400, 400, 200}, 3));

        // Render lines
        renderer.setColor(Color.blue);
        Stroke bold = new BasicStroke(3, BasicStroke.CAP_BUTT, BasicStroke.JOIN_BEVEL, 0, new float[]{1000}, 0);
        renderer.setStroke(bold);
        renderer.drawLine(200, 400, 200, 600);
        renderer.drawLine(400, 400, 400, 600);
        renderer.drawLine(500, 400, 500, 600);
        renderer.drawLine(600, 400, 600, 600);

        renderer.drawLine(200, 400, 600, 400);
        renderer.drawLine(200, 600, 400, 600);
        renderer.drawLine(500, 600, 600, 600);

        renderer.drawLine(200, 400, 400, 200);
        renderer.drawLine(400, 200, 600, 400);

        // Render grid
        Stroke dashed = new BasicStroke(1, BasicStroke.CAP_BUTT, BasicStroke.JOIN_BEVEL, 0, new float[]{3}, 0);
        renderer.setStroke(dashed);
        renderer.drawLine(100, 100, 100, 700);
        renderer.drawLine(200, 100, 200, 700);
        renderer.drawLine(300, 100, 300, 700);
        renderer.drawLine(400, 100, 400, 700);
        renderer.drawLine(500, 100, 500, 700);
        renderer.drawLine(600, 100, 600, 700);
        renderer.drawLine(700, 100, 700, 700);

        renderer.drawLine(100, 100, 700, 100);
        renderer.drawLine(100, 200, 700, 200);
        renderer.drawLine(100, 300, 700, 300);
        renderer.drawLine(100, 400, 700, 400);
        renderer.drawLine(100, 500, 700, 500);
        renderer.drawLine(100, 600, 700, 600);
        renderer.drawLine(100, 700, 700, 700);

        // Render text
        renderer.setColor(Color.black);
        renderer.drawString("100", 100, 100);
        renderer.drawString("200", 100, 200);
        renderer.drawString("300", 100, 300);
        renderer.drawString("400", 100, 400);
        renderer.drawString("500", 100, 500);
        renderer.drawString("600", 100, 600);
        renderer.drawString("700", 100, 700);

        renderer.drawString("200", 200, 100);
        renderer.drawString("300", 300, 100);
        renderer.drawString("400", 400, 100);
        renderer.drawString("500", 500, 100);
        renderer.drawString("600", 600, 100);
        renderer.drawString("700", 700, 100);

        // Render dots
        System.out.print("Enter number of dots: ");
        Scanner scan = new Scanner(System.in);
        int numberOfDots = scan.nextInt();
        for (int i = 0; i < numberOfDots; i++) {
            System.out.print("Enter x and y for dot " + (i + 1) + ": ");
            int x = scan.nextInt();
            int y = scan.nextInt();

            if (dotIsInHouse(x, y)) {
                renderer.setColor(Color.BLACK);
                drawDot(renderer, x, y);
            } else {
                renderer.setColor(Color.lightGray);
                drawDot(renderer, x, y);
            }
        }

        // Finally, stream out SVG to the standard output using UTF-8 encoding.
        boolean useCSS = true; // we want to use CSS style attributes
        System.setOut(new PrintStream(new BufferedOutputStream(new FileOutputStream("PaintAHouse.svg"))));
        Writer out = new OutputStreamWriter(System.out, "UTF-8");
        renderer.stream(out, useCSS);
    }

    public static void drawDot(SVGGraphics2D renderer, int x, int y) {
        renderer.fillOval(x - 5, y - 5, 10, 10);
    }

    public static boolean dotIsInHouse(int x, int y) {
        boolean isInLeftRectangle =
                x >= 200 && x <= 400 &&
                y >= 400 && y <= 600;
        boolean isInRightRectangle =
                x >= 500 && x <= 600 &&
                y >= 400 && y <= 500;

        boolean isRightToA = ((200 - x)*(200 - y) - (400 - y)*(400 - x)) >= 0;
        boolean isLeftToB = ((600 - x)*(200 - y) - (200 - y)*(400 - x)) <= 0;
        boolean isAboveC = y <= 400;
        boolean isInTriangle = isRightToA && isLeftToB && isAboveC;

        return isInLeftRectangle || isInRightRectangle || isInTriangle;
    }
}