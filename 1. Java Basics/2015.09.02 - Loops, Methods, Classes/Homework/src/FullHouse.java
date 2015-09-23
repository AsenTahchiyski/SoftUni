import java.text.MessageFormat;

public class FullHouse {
    private static final String[] suits = {"♠", "♥", "♦", "♣"};
    private static final String[] values =
            {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

    public static void main(String[] args) {
        int totalCombinations = 0;
        for (int card1 = 0; card1 < values.length; card1++) {
            for (int suit1 = 0; suit1 < suits.length; suit1++) {
                for (int card2 = 0; card2 < values.length; card2++) {
                    for (int suit2 = 0; suit2 < suits.length; suit2++) {
                        if (card1 != card2) {
                            int suitLastCard = (suit2 + 1) % 4;
                            for (int lastSuit = suitLastCard;
                                 lastSuit < 3; lastSuit++) {
                                System.out.println(MessageFormat.format(
                                        "{0}{1} {0}{2} {0}{3} {4}{5} {4}{6}",
                                        values[card1], suits[suit1],
                                        suits[(suit1 + 1) % suits.length],
                                        suits[(suit1 + 2) % suits.length],
                                        values[card2], suits[suit2],
                                        suits[suitLastCard]));
                                totalCombinations++;
                            }
                        }
                    }
                }
            }
        }
        System.out.println(totalCombinations + " combinations total");
    }
}
