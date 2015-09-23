import java.util.Locale;
import java.util.Scanner;

public class PointsInsideHouse {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scan = new Scanner(System.in);

        while (true) {
            float x = scan.nextFloat();
            float y = scan.nextFloat();

            boolean inLeftRectangle =
                    x >= 12.5 && x <= 17.5 &&
                    y >= 8.5 && y <= 13.5;
            boolean inRightRectangle =
                    x >= 20 && x <= 22.5 &&
                    y >= 8.5 && y <= 13.5;

            boolean isRightToA = ((12.5 - x)*(3.5 - y) - (8.5 - y)*(17.5 - x)) >= 0;
            boolean isLeftToB = ((22.5 - x)*(3.5 - y) - (8.5 - y)*(17.5 - x)) <= 0;
            boolean isAboveC = y <= 8.5;
            boolean isInTriangle = isRightToA && isLeftToB && isAboveC;

            System.out.println("Inside of house: " + (isInTriangle || inLeftRectangle || inRightRectangle));
        }
    }
}
