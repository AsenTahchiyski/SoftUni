import java.util.Scanner;

public class p02_possibleTriangles {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        boolean triangleFound = false;
        while(!line.equals("End")) {
            String[] numbers = line.split("\\s+");
            double a = Double.parseDouble(numbers[0]);
            double b = Double.parseDouble(numbers[1]);
            double c = Double.parseDouble(numbers[2]);
            if (a > b) {
                double temp = a;
                a = b;
                b = temp;
            }

            if ((a + b > c) && a < c && b < c && a != b && b != c && a != c) {
                System.out.printf("%.2f+%.2f>%.2f", a, b, c).println();
                triangleFound = true;
            }
            else if ((b + c > a) && b < a && c < a && a != b && b != c && a != c) {
                System.out.printf("%.2f+%.2f>%.2f", b, c, a).println();
                triangleFound = true;
            } else if ((a + c > b) && a < b && c < b && a != b && b != c && a != c) {
                System.out.printf("%.2f+%.2f>%.2f", a, c, b).println();
                triangleFound = true;
            }

            line = scan.nextLine();
        }

        if (!triangleFound) {
            System.out.println("No");
        }
    }
}
