import java.util.Locale;
import java.util.Scanner;

public class PointsInsideFigure {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);

        Scanner scan = new Scanner(System.in);
        float pointX = scan.nextFloat();
        float pointY = scan.nextFloat();

        boolean isInTopRectangle =
                pointX >= 12.5 && pointX <= 22.5 &&
                pointY >= 6 && pointY <= 8.5;
        boolean isInLeftRectangle =
                pointX >= 12.5 && pointX <= 17.5 &&
                pointY >= 8.5 && pointY <= 13.5;
        boolean isInRightRectangle =
                pointX >= 20 && pointX <= 22.5 &&
                pointY >= 8.5 && pointY <= 13.5;

        if (isInTopRectangle || isInLeftRectangle || isInRightRectangle) {
            System.out.println("Inside");
        } else {
            System.out.println("Outside");
        }
    }
}
