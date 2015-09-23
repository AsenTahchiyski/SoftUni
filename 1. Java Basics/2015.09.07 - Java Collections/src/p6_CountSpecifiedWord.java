import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p6_CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        String word = scan.nextLine();
        Pattern pattern = Pattern.compile("\\w+");
        Matcher matcher = pattern.matcher(text);
        int numberOfWords = 0;
        while (matcher.find()) {
            if (matcher.group().toLowerCase().compareTo(word.toLowerCase()) == 0) {
                numberOfWords++;
            }
        }
        System.out.println(numberOfWords);
    }
}
