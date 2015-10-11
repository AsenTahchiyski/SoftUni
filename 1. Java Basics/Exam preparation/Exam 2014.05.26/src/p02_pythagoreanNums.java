import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class p02_pythagoreanNums {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalNumbers = Integer.parseInt(scan.nextLine());
        int[] numbers = new int[totalNumbers];
        for (int i = 0; i < totalNumbers; i++) {
            numbers[i] = Integer.parseInt(scan.nextLine());
        }

        ArrayList<String> usedCombos = new ArrayList<>();
        boolean comboFound = false;
        for (int i = 0; i < totalNumbers; i++) {
            for (int j = 0; j < totalNumbers; j++) {
                for (int k = 0; k < totalNumbers; k++) {
                    int a = numbers[i];
                    int b = numbers[j];
                    int c = numbers[k];
                    if (a * a + b * b == c * c) {
                        int[] usedCombo = {a, b, c};
                        Arrays.sort(usedCombo);
                        a = usedCombo[0];
                        b = usedCombo[1];
                        c = usedCombo[2];
                        String combo = a + "|" + b + "|" + c;
                        if (!usedCombos.contains(combo)) {
                            System.out.println(a + "*" + a + " + " +
                                    b + "*" + b + " = " + c + "*" + c);
                            usedCombos.add(combo);
                            comboFound = true;
                        }
                    }
                }
            }
        }

        if (!comboFound) {
            System.out.println("No");
        }
    }
}
