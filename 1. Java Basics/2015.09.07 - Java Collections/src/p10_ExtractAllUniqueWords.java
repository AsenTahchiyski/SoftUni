import java.util.Scanner;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p10_ExtractAllUniqueWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        Pattern pattern = Pattern.compile("[A-Za-z]+");
        Matcher matcher = pattern.matcher(text);
        TreeSet<String> setOfWords = new TreeSet<>();
        while(matcher.find()) {
            setOfWords.add(matcher.group().toLowerCase());
        }
        System.out.println(String.join(" ", setOfWords));
    }
}
