import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class p04_straightFlush {
    private static final String[] suits = {"S", "H", "D", "C"};
    private static final String[] faces =
            {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    //        0    1    2    3    4    5    6    7     8    9   10   11   12

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        String[] cards = line.split(",");
        for (int i = 0; i < cards.length; i++) {
            cards[i] = cards[i].trim();
        }
        if (cards.length < 5) {
            System.out.println("No Straight Flushes");
            return;
        }
        boolean foundStraightFlush = false;
        for (String card : cards) {
            String face = getFace(card);
            String suit = getSuit(card);
            if (formsStraightFlush(face, suit, cards)) {
                String[] flush = getStraightFlushArray(face, suit);
                System.out.println("[" + String.join(", ", flush) + "]");
                foundStraightFlush = true;
            }
        }

        if (!foundStraightFlush) {
            System.out.println("No Straight Flushes");
        }
    }

    private static String getFace(String card) {
        String face;
        if (card.length() == 2) {
            face = Character.toString(card.charAt(0));
        } else if (card.length() == 3) {
//            face = card.substring(0, 2);
            face = "10";
        } else {
            face = null;
        }
        return face;
    }

    private static String getSuit(String card) {
        String suit;
        if (card.length() == 2) {
            suit = Character.toString(card.charAt(1));
        } else if (card.length() == 3) {
            suit = Character.toString(card.charAt(2));
        } else {
            suit = null;
        }
        return suit;
    }

    private static boolean formsStraightFlush(String face, String suit, String[] cards) {
        int faceIndex = Arrays.asList(faces).indexOf(face);
        int suitIndex = Arrays.asList(suits).indexOf(suit);
        List cardsList = Arrays.asList(cards);
        if (faceIndex > 8) {
            return false;
        }
        boolean cardPlus1Present = cardsList.contains(faces[faceIndex + 1] + suits[suitIndex]);
        boolean cardPlus2Present = cardsList.contains(faces[faceIndex + 2] + suits[suitIndex]);
        boolean cardPlus3Present = cardsList.contains(faces[faceIndex + 3] + suits[suitIndex]);
        boolean cardPlus4Present = cardsList.contains(faces[faceIndex + 4] + suits[suitIndex]);
        if (cardPlus1Present && cardPlus2Present && cardPlus3Present && cardPlus4Present) {
            return true;
        }
        return false;
    }

    private static String[] getStraightFlushArray(String face, String suit) {
        String[] flush = new String[5];
        int faceIndex = Arrays.asList(faces).indexOf(face);
        for (int i = 0; i < 5; i++) {
            flush[i] = faces[faceIndex + i] + suit;
        }
        return flush;
    }
}
