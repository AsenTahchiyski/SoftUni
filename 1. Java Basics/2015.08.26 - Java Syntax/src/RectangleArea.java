import java.util.Scanner;

public class RectangleArea {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int firstNumber = scanner.nextInt();
        int secondNumber = scanner.nextInt();
        System.out.printf("Area of a rectangle %dx%d = %d", firstNumber, secondNumber, firstNumber * secondNumber);
    }
}
