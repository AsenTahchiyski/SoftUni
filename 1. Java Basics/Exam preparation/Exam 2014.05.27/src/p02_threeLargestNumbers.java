import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Scanner;

public class p02_threeLargestNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalNumbers = Integer.parseInt(scan.nextLine());
        BigDecimal[] numbers = new BigDecimal[totalNumbers];
        for (int i = 0; i < totalNumbers; i++) {
            numbers[i] = new BigDecimal(scan.nextLine());
        }

        Arrays.sort(numbers);
        for (int i = 0; i < Integer.min(3, numbers.length); i++) {
            BigDecimal currentNum = numbers[numbers.length - 1 - i];
            System.out.println(currentNum.toPlainString());
        }
    }
}
