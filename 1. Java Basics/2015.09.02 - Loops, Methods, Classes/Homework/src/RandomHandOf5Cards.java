import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

public class RandomHandOf5Cards {
    private static final String[] suits = {"♠", "♥", "♦", "♣"};
    private static final String[] faces =
            {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    private static Random random = new Random();

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.print("Enter number of random hands to generate: ");
        int numberOfHands = scan.nextInt();
        for (int i = 0; i < numberOfHands; i++) {
            Card[] cards = new Card[5];
            cards[0] = new Card(random.nextInt(13),random.nextInt(4));
            for (int card = 1; card < 5; card++) {
                cards[card] = getNextUniqueCard(cards);
            }

            System.out.printf("%s%s %s%s %s%s %s%s %s%s",
                    faces[cards[0].getFace()], suits[cards[0].getSuit()],
                    faces[cards[1].getFace()], suits[cards[1].getSuit()],
                    faces[cards[2].getFace()], suits[cards[2].getSuit()],
                    faces[cards[3].getFace()], suits[cards[3].getSuit()],
                    faces[cards[4].getFace()], suits[cards[4].getSuit()]
                    );
            System.out.println();
        }
    }

    public static Card getNextUniqueCard(Card[] cards) {
        Card card;
        do {
                card = new Card(random.nextInt(13), random.nextInt(4));
        } while (Arrays.asList(cards).contains(card));
        return card;
    }
}
