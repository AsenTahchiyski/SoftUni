import java.util.Scanner;

public class SymmetricNumsInRange {
    public static void main(String[] args) {
        System.out.print("Enter start and end of range: ");
        Scanner scan = new Scanner(System.in);
        int start = scan.nextInt();
        int end = scan.nextInt();
        for (int i = start; i <= end; i++) {
            if (isSymmetric(i)) {
                System.out.println(i + " ");
            }
        }
    }

    private static boolean isSymmetric(int i) {
        String numAsString = Integer.toString(i);
        int length = numAsString.length();
        if (length == 1) {
            return true;
        } else if (length == 2) {
            if (numAsString.charAt(0) == numAsString.charAt(1)) {
                return true;
            } else {
                return false;
            }
        } else if (length % 2 == 0) {
            String firstHalf = numAsString.substring(0, length/2 - 1);
            String secondHalf = numAsString.substring(length/2, length - 1);
            StringBuilder secondHalfReversed = new StringBuilder();
            secondHalfReversed.append(secondHalf).reverse();
            if (firstHalf == secondHalfReversed.toString()) {
                return true;
            } else {
                return false;
            }
        } else if (length % 2 == 1) {
            String firstHalf = numAsString.substring(0, length / 2);
            String secondHalf = numAsString.substring(length / 2 + 1, length);
            StringBuilder secondHalfReversed = new StringBuilder();
            secondHalfReversed.append(secondHalf).reverse();
            if (firstHalf.equals(secondHalfReversed.toString())) {
                return true;
            } else {
                return false;
            }
        }

        return false;
    }
}
