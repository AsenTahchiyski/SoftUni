import java.text.MessageFormat;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class p12_CardsFrequencies {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] cards = scan.nextLine().split("\\s+");
        String[] cardFaces = new String[cards.length];
        for (int i = 0; i < cards.length; i++) {
            if (cards[i].length() == 2) {
                cardFaces[i] = cards[i].substring(0, 1);
            } else {
                cardFaces[i] = cards[i].substring(0, 2);
            }
        }
        Map<String, Integer> data = new LinkedHashMap<>();
        for (String cardFace : cardFaces) {
            if (!data.containsKey(cardFace)) {
                data.put(cardFace, 0);
            }
            data.put(cardFace, data.get(cardFace) + 1);
        }
        double totalElements = cardFaces.length;
        for (Map.Entry<String, Integer> pair : data.entrySet()) {
            System.out.printf("%s -> %.2f%s", pair.getKey(), pair.getValue() * 100 / totalElements, "%");
            System.out.println();
        }
    }
}
