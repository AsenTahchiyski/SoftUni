import java.util.Scanner;

public class DecToHex {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number = scan.nextInt();
        String hex = Integer.toHexString(number);
        System.out.println(hex.toUpperCase());
    }
}
