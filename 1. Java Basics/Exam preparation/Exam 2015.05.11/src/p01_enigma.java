import java.util.Scanner;

public class p01_enigma {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalLines = Integer.parseInt(scan.nextLine());
        for (int i = 0; i < totalLines; i++) {
            String line = scan.nextLine();
            int length = 0;
            for (int j = 0; j < line.length(); j++) {
                if (!Character.isDigit(line.charAt(j)) && !Character.isWhitespace(line.charAt(j))) {
                    length++;
                }
            }

            char[] array = line.toCharArray();
            for (int j = 0; j < array.length; j++) {
                if (!Character.isDigit(array[j]) && !Character.isWhitespace(array[j])) {
                    char encrypted = array[j];
                    char decrypted = (char)(encrypted + length / 2);
                    array[j] = decrypted;
                }
            }

            System.out.println(new String(array));
        }
    }
}
