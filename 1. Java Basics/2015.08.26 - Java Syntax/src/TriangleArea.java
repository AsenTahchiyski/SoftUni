import java.util.Scanner;

public class TriangleArea {
    public static void main(String[] args) {
        System.out.print("Enter coordinates for the three points: ");
        Scanner scan = new Scanner(System.in);

        int firstX = scan.nextInt();
        int firstY = scan.nextInt();
        int secondX = scan.nextInt();
        int secondY = scan.nextInt();
        int thirdX = scan.nextInt();
        int thirdY = scan.nextInt();

        int area = Math.abs(
                (firstX - thirdX) * (secondY - firstY) -
                (firstX - secondX) * (thirdY - firstY)) / 2;
        System.out.println("Triangle area = " + area);
    }
}
