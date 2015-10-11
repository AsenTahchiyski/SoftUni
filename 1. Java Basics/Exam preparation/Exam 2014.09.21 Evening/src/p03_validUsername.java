import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p03_validUsername {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        Pattern pattern = Pattern.compile("([^\\s\\\\\\/)(]*[A-Za-z]\\w{1,}[^\\s\\\\\\/)(])");
        Matcher matcher = pattern.matcher(line);
        int longestPair = 0;
        int indexFirst = -1;
        ArrayList<String> validNames = new ArrayList<>();
        while (matcher.find()) {
            String name = matcher.group();
            if (Character.isLetter(name.charAt(0)) && name.length() < 26) {
                validNames.add(name);
            }
        }

        for (int i = 0; i < validNames.size() - 1; i++) {
            int lengthFirst = validNames.get(i).length();
            int lengthSecond = validNames.get(i + 1).length();
            if (lengthFirst + lengthSecond > longestPair) {
                longestPair = lengthFirst + lengthSecond;
                indexFirst = i;
            }
        }

        System.out.println(validNames.get(indexFirst));
        System.out.println(validNames.get(indexFirst + 1));
    }
}
