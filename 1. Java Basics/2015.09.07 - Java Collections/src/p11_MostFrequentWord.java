import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p11_MostFrequentWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        Pattern pattern = Pattern.compile("[A-Za-z]+");
        Matcher matcher = pattern.matcher(text);
        TreeMap<String, Integer> data = new TreeMap<>();
        int mostFrequent = 0;
        while(matcher.find()) {
            String word = matcher.group().toLowerCase();
            if (!data.containsKey(word)) {
                data.put(word, 0);
            }
            data.put(word, data.get(word) + 1);
            if (data.get(word) > mostFrequent) {
                mostFrequent = data.get(word);
            }
        }
        for (Map.Entry<String, Integer> set : data.entrySet()) {
            if (set.getValue() == mostFrequent) {
                System.out.printf("%s -> %d times", set.getKey(), set.getValue());
                System.out.println();
            }
        }
    }
}
