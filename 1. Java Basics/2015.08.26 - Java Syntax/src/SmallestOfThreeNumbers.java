import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class SmallestOfThreeNumbers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);

        Scanner scan = new Scanner(System.in);
        float number1 = scan.nextFloat();
        float number2 = scan.nextFloat();
        float number3 = scan.nextFloat();
        float smallestNumber = Math.min(Math.min(number1, number2), number3);

        String result;
        if (smallestNumber == (int) smallestNumber) {
            result = String.format("%d", (int) smallestNumber);
        } else {
            DecimalFormat df = new DecimalFormat("0.###");
            result = df.format(smallestNumber);
        }

        System.out.print("Smallest number is " + result);
    }
}