import java.util.ArrayList;
import java.util.Scanner;

public class p03_weirdString {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        line = line.replaceAll("[)(\\|\\\\\\s]+", "");
        String[] words = line.split("[\\W0-9_]");
        words = removeEmptyElements(words);
        int longestIndex = -1;
        int maxSum = 0;
        for (int i = 0; i < words.length - 1; i++) {
            int currentSum = getWordWeight(words[i]) + getWordWeight(words[i + 1]);
            if (currentSum >= maxSum) {
                longestIndex = i;
                maxSum = currentSum;
            }
        }

        System.out.println(words[longestIndex]);
        System.out.println(words[longestIndex + 1]);
    }

    private static String[] removeEmptyElements(String[] input) {
        ArrayList<String> validWords = new ArrayList<>();
        for (String s : input) {
            if (!s.equals("")) {
                validWords.add(s);
            }
        }

        String[] result = new String[validWords.size()];
        return validWords.toArray(result);
    }

    private static int getWordWeight(String word) {
        int result = 0;
        for (int i = 0; i < word.length(); i++) {
            result += Character.toUpperCase(word.charAt(i)) - 'A' - 1;
        }

        return result;
    }
}
