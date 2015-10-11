import java.util.ArrayList;
import java.util.Scanner;

public class p01_mirrorNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int numbersCount = Integer.parseInt(scan.nextLine());
        ArrayList<Integer> skipIndex = new ArrayList<>();
        skipIndex.add(0);
        String[] numbers = scan.nextLine().split("\\s+");
        boolean foundAny = false;
        for (int i = 0; i < numbers.length; i++) {
            for (int j = 0; j < numbers.length; j++) {
                if (!skipIndex.contains(j) || !skipIndex.contains(i)) {
                    String reversed = reverse(numbers[j]);
                    if (numbers[i].equals(reversed) && numbers[i] != numbers[j]) {
                        System.out.printf("%s<!>%s", numbers[i], numbers[j]).println();
                        skipIndex.add(j);
                        skipIndex.add(i);
                        foundAny = true;
                    }
                }
            }
        }

        if (!foundAny) {
            System.out.println("No");
        }
    }

    private static String reverse(String input) {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < input.length(); i++) {
            result.append(input.charAt(input.length() - 1 - i));
        }

        return result.toString();
    }
}
