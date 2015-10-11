import java.util.Scanner;

public class p02_lettersChangeNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] combos = scan.nextLine().split("\\s+");
        double result = 0;
        for (String combo : combos) {
            result += getComboValue(combo);
        }

        System.out.printf("%.2f", result);
    }

    private static double getComboValue(String combo) {
        char firstLetter = combo.charAt(0);
        char lastLetter = combo.charAt(combo.length() - 1);
        int number = Integer.parseInt(combo.substring(1, combo.length() - 1));
        double result = number;
        // process first letter
        if (Character.isLowerCase(firstLetter)) {
            result *= getLetterPosition(firstLetter);
        } else if (Character.isUpperCase(firstLetter)) {
            result /= getLetterPosition(firstLetter);
        }

        // process second letter
        if (Character.isLowerCase(lastLetter)) {
            result += getLetterPosition(lastLetter);
        } else if (Character.isUpperCase(lastLetter)) {
            result -= getLetterPosition(lastLetter);
        }

        return result;
    }

    private static int getLetterPosition(char letter) {
        return (int)Character.toLowerCase(letter) - 96;
    }
}
