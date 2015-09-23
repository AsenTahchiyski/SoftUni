import java.util.Scanner;

public class CountOfBitsOne {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number = scan.nextInt();
        int ones = Integer.bitCount(number);
        System.out.println(ones + " ones in " + number);
    }
}
