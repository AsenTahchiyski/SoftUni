import java.util.Scanner;

public class p02_durts {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int centerX = scan.nextInt();
        int centerY = scan.nextInt();
        int radius = scan.nextInt();
        int shots = scan.nextInt();
        for (int i = 0; i < shots; i++) {
            int shotX = scan.nextInt();
            int shotY = scan.nextInt();
            boolean isInVerticalRectangle =
                    Math.abs(shotY - centerY) <= radius &&
                    Math.abs(centerX - shotX) <= radius / 2;
            boolean isInHorizontalRectangle =
                    Math.abs(shotX - centerX) <= radius &&
                    Math.abs(shotY - centerY) <= radius / 2;
            if (isInVerticalRectangle || isInHorizontalRectangle) {
                System.out.println("yes");
            } else {
                System.out.println("no");
            }
        }
    }
}
