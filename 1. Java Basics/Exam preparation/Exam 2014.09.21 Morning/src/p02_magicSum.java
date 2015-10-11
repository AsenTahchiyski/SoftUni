import java.util.ArrayList;
import java.util.Scanner;

public class p02_magicSum {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int divisor = Integer.parseInt(scan.nextLine());
        String line = scan.nextLine();
        ArrayList<Integer> numbers = new ArrayList<>();
        while (!line.equals("End")) {
            int number = Integer.parseInt(line);
            numbers.add(number);
            line = scan.nextLine();
        }

        boolean magicSumFound = false;
        int maxSum = Integer.MIN_VALUE;
        int[] numbersIndexes = new int[3];
        for (int first = 0; first < numbers.size(); first++) {
            for (int sec = 0; sec < numbers.size(); sec++) {
                if (first == sec) { continue; }
                for (int third = 0; third < numbers.size(); third++) {
                    if (sec == third || first == third) { continue; }
                    int sum = numbers.get(first) + numbers.get(sec) + numbers.get(third);
                    if (sum > maxSum && sum % divisor == 0) {
                        maxSum = sum;
                        numbersIndexes[0] = first;
                        numbersIndexes[1] = sec;
                        numbersIndexes[2] = third;
                        magicSumFound = true;
                    }
                }
            }
        }

        if (magicSumFound) {
            System.out.println("(" + numbers.get(numbersIndexes[0]) + " + " + numbers.get(numbersIndexes[1]) +
                    " + " + numbers.get(numbersIndexes[2]) + ") % " + divisor + " = 0");
        } else {
            System.out.println("No");
        }
    }
}
