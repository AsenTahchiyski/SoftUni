import java.util.Scanner;

public class p01_dozenEggs {
    private static final int numberOfLines = 7;
    private static final int eggsInPack = 12;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalEggsAmount = 0;
        for (int i = 0; i < numberOfLines; i++) {
            String[] lineParams = scan.nextLine().split("\\s+");
            int amount = Integer.parseInt(lineParams[0]);
            String type = lineParams[1];

            if (type.equals("dozens")) {
                totalEggsAmount += amount * eggsInPack;
            } else if (type.equals("eggs")) {
                totalEggsAmount += amount;
            }
        }

        System.out.printf("%d dozens + %d eggs",
                (int)(totalEggsAmount / eggsInPack), (int)(totalEggsAmount % eggsInPack));
    }
}
