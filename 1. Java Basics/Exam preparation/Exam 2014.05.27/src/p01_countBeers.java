import java.util.Scanner;

public class p01_countBeers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        int[] totalAmount = new int[2];
        while(!line.equals("End")) {
            String[] params = line.split(" ");
            String type = params[1];
            int amount = Integer.parseInt(params[0]);
            if (type.equals("stacks")) {
                totalAmount[1] += amount;
            } else if (type.equals("beers")) {
                totalAmount[0] += amount;
            }

            line = scan.nextLine();
        }

        int stacksFromBeers = totalAmount[0] / 20;
        totalAmount[0] %= 20;
        totalAmount[1] += stacksFromBeers;
        System.out.println(totalAmount[1] + " stacks + " + totalAmount[0] + " beers");
    }
}
