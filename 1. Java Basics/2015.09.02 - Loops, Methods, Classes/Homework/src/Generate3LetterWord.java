import java.util.Scanner;

public class Generate3LetterWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        char[] letters = scan.next().toCharArray();
        for (int i = 0; i < letters.length; i++) {
            for (int j = 0; j < letters.length; j++) {
                for (int k = 0; k < letters.length; k++) {
                    System.out.printf("%s%s%s ", letters[i], letters[j], letters[k]);
                }
            }
        }
    }
}
