import java.util.Scanner;

public class p14_StuckNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int numbersCount = scan.nextInt();
        String[] numbers = new String[numbersCount];
        for (int i = 0; i < numbersCount; i++) {
            numbers[i] = scan.next();
        }
        boolean stuckNumbersFound = false;
        for (int first = 0; first < numbersCount; first++) {
            for (int second = 0; second < numbersCount; second++) {
                if (first != second) {
                    for (int third = 0; third < numbersCount; third++) {
                        if (third != first && third != second) {
                            for (int fourth = 0; fourth < numbersCount; fourth++) {
                                if (fourth != third && fourth != second && fourth != first) {
                                    if ((numbers[first] + numbers[second])
                                            .compareTo(numbers[third] + numbers[fourth]) == 0) {
                                        System.out.printf("%s|%s==%s|%s", numbers[first], numbers[second],
                                                numbers[third], numbers[fourth]);
                                        System.out.println();
                                        stuckNumbersFound = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (!stuckNumbersFound) {
            System.out.println("No");
        }
    }
}
