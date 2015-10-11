import java.util.Scanner;

public class p02_magicCard {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] cards = scan.nextLine().split(" ");
        String evenOdd = scan.nextLine();
        String magicCard = scan.nextLine();
        String magicFace = magicCard.substring(0, magicCard.length() - 1);
        char magicSuit = magicCard.charAt(magicCard.length() - 1);
        int startIndex = evenOdd.equals("even") ? 0 : 1;
        int result = 0;
        for (int i = startIndex; i < cards.length; i += 2) {
            int cardValue = getCardValue(cards[i]);
            String cardFace = cards[i].substring(0, cards[i].length() - 1);
            char cardSuit = cards[i].charAt(cards[i].length() - 1);
            if (cardSuit == magicSuit) {
                cardValue *= 2;
            }
            if (cardFace.equals(magicFace)) {
                cardValue *= 3;
            }

            result += cardValue;
        }

        System.out.println(result);
    }

    private static int getCardValue(String card) {
        if (Character.isDigit(card.charAt(0))) {
            int face = Integer.parseInt(card.substring(0, card.length() - 1));
            return face * 10;
        } else {
            switch (card.charAt(0)) {
                case 'J':
                    return 120;
                case 'Q':
                    return 130;
                case 'K':
                    return 140;
                case 'A':
                    return 150;
                default:
                    return 0;
            }
        }
    }
}
