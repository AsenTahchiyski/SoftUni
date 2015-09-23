import java.util.Scanner;

public class CountOfEqualBitPairs {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number = scan.nextInt();
        String binary = Integer.toBinaryString(number);
        char[] charArr = binary.toCharArray();
        int pairs = 0;

        for (int i = 0; i < charArr.length - 1; i++) {
            if (charArr[i] == charArr[i + 1]) {
                pairs++;
            }
        }

        System.out.printf("%d pairs in %s", pairs, binary);
    }
}
