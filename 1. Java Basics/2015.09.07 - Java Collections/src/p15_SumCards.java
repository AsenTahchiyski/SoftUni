import java.util.Scanner;

public class p15_SumCards {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] cards = scan.nextLine().split("\\s+");
        int totalCards = cards.length;

        // add one cell with value 0 at the end to always allow comparing to next element
        String[] faces = new String[totalCards + 1];

        for (int i = 0; i < totalCards; i++) {
            String card = cards[i];
            if (card.length() == 2) {
                faces[i] = card.substring(0, 1);
            } else {
                faces[i] = card.substring(0, 2);
            }
        }

        faces[totalCards] = "0";

        int totalCardValue = 0;
        for (int i = 0; i < totalCards; i++) {
            totalCardValue += getRealCardValue(faces, i);
        }

        System.out.println(totalCardValue);
    }

    private static int getCardFaceValue(String cardFace) {
        switch (cardFace) {
            case "2": return 2;
            case "3": return 3;
            case "4": return 4;
            case "5": return 5;
            case "6": return 6;
            case "7": return 7;
            case "8": return 8;
            case "9": return 9;
            case "10": return 10;
            case "J": return 12;
            case "Q": return 13;
            case "K": return 14;
            case "A": return 15;
            default: return 0;
        }
    }

    private static int getRealCardValue(String[] faces, int i) {
        int totalCardValue = 0;
        boolean isNextCardDifferent = faces[i].compareTo(faces[i + 1]) != 0;
        boolean isPreviousCardDifferent = true;
        if (i > 0) {
            isPreviousCardDifferent = faces[i].compareTo(faces[i - 1]) != 0;
        }
        if (isNextCardDifferent) {
            if (!isPreviousCardDifferent) {
                totalCardValue += getCardFaceValue(faces[i]) * 2;
            } else {
                totalCardValue += getCardFaceValue(faces[i]);
            }
        } else {
            totalCardValue += getCardFaceValue(faces[i]) * 2;
        }

        return totalCardValue;
    }
}
