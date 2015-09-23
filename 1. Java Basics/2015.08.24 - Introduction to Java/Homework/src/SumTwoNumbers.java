import java.text.MessageFormat;
import java.util.Scanner;

public class SumTwoNumbers {
    public static void main(String[] args) {
        int first, second;
        System.out.print("Enter two numbers to sum: ");
        Scanner input = new Scanner(System.in);
        first = input.nextInt();
        second = input.nextInt();
        System.out.print(MessageFormat.format("The sum of {0} and {1} is {2}",
                first, second, first + second));
    }
}
