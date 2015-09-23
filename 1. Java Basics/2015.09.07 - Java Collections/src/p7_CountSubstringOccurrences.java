import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p7_CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        String substring = scan.nextLine();
        Pattern pattern = Pattern.compile("\\w+");
        Matcher matcher = pattern.matcher(text);
        int numberOfWords = 0;
        while (matcher.find()) {
            String match = matcher.group().toLowerCase();
            if (match.length() < substring.length()) {
                continue;
            }
            for (int i = 0; i <= match.length() - substring.length(); i++) {
                String submatch = match.substring(i, i + substring.length());
                if (submatch.compareTo(substring) == 0) {
                    numberOfWords++;
                }
            }
        }
        System.out.println(numberOfWords);
    }
}
