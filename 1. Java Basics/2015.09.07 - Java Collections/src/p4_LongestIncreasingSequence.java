import java.util.Scanner;

public class p4_LongestIncreasingSequence {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        String[] numbersAsStrings = line.split("\\s+");
        int[] numbers = new int[numbersAsStrings.length];
        for (int i = 0; i < numbersAsStrings.length; i++) {
            numbers[i] = Integer.parseInt(numbersAsStrings[i]);
        }
        int maxSequenceLength = 1;
        int sequenceEndIndex = 0;
        int sequenceLength = 1;
        int lastNumberIndex = 0;
        for (int i = 0; i < numbers.length - 1; i++) {
            if (numbers[i + 1] - numbers[i] > 0) {
                sequenceLength++;
                if (maxSequenceLength < sequenceLength) {
                    sequenceEndIndex = i + 1;
                    maxSequenceLength = sequenceLength;
                }
                System.out.print(numbers[i] + " ");
            } else {
                if (sequenceLength > 0) {
                    System.out.println(numbers[i]);
                } else {
                    System.out.println(numbers[i]);
                }
                sequenceLength = 1;
            }
            lastNumberIndex = i + 1;
        }
        if (sequenceLength > 0) {
            System.out.println(numbers[lastNumberIndex]);
        }
        System.out.print("Longest: ");
        for (int i = sequenceEndIndex - maxSequenceLength + 1; i <= sequenceEndIndex; i++) {
            System.out.print(numbers[i] + " ");
        }
    }
}
