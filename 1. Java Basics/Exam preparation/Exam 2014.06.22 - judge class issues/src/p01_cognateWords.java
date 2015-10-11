import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p01_cognateWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        Pattern pattern = Pattern.compile("[A-Za-z]+");
        Matcher matcher = pattern.matcher(line);
        ArrayList<String> words = new ArrayList<>();
        while(matcher.find()) {
            words.add(matcher.group());
        }
        boolean cognateWordsFound = false;
        ArrayList<String> combinations = new ArrayList<>();
        for (int i = 0; i < words.size(); i++) {
            for (int j = 0; j < words.size(); j++) {
                String combo = words.get(i) + words.get(j);
                if (words.contains(combo) && !combinations.contains(combo)) {
                    System.out.printf("%s|%s=%s", words.get(i), words.get(j), combo);
                    System.out.println();
                    combinations.add(combo);
                    cognateWordsFound = true;
                }
            }
        }
        if (!cognateWordsFound) {
            System.out.println("No");
        }
    }
}
