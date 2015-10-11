import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p03_longestOddEvenSequence {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        Pattern pattern = Pattern.compile("\\(\\s*(-?\\d+)\\s*\\)");
        Matcher matcher = pattern.matcher(input);
        ArrayList<Integer> numbers = new ArrayList<>();
        while (matcher.find()) {
            numbers.add(Integer.parseInt(matcher.group(1)));
        }

        int currentLength = 1;
        int maxLength = 1;
        for (int i = 1; i < numbers.size(); i++) {
            boolean isPrevEven = numbers.get(i - 1) % 2 == 0 ? true : false;
            boolean isThisEven = numbers.get(i) % 2 == 0 ? true : false;
            if (isPrevEven != isThisEven || numbers.get(i) == 0 || numbers.get(i - 1) == 0) {
                currentLength++;
            } else {
                if (currentLength > 1 && currentLength > maxLength) {
                    maxLength = currentLength;
                }

                currentLength = 1;
                isPrevEven = numbers.get(i) % 2 == 0 ? true : false;
            }
        }

        if (currentLength > 1 && currentLength > maxLength) {
            maxLength = currentLength;
        }

        System.out.println(maxLength);
    }
}
