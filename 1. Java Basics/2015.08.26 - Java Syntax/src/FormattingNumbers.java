import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class FormattingNumbers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);

        Scanner scan = new Scanner(System.in);
        int a = scan.nextInt();
        float b = scan.nextFloat();
        float c = scan.nextFloat();

        String hex = Integer.toHexString(a).toUpperCase();
        String bin = String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0');
        DecimalFormat decFormat1 = new DecimalFormat("0.00");
        DecimalFormat decFormat2 = new DecimalFormat("0.000");
        System.out.printf("|%-10s|%s|%10s|%-10s|", hex, bin, decFormat1.format(b), decFormat2.format(c));
    }
}
