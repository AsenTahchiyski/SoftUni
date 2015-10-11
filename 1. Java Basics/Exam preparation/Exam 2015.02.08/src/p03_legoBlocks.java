import java.util.ArrayList;
import java.util.Scanner;

public class p03_legoBlocks {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int rows = Integer.parseInt(scan.nextLine().trim());
        ArrayList<String[]> firstArray = new ArrayList<>();
        ArrayList<String[]> secondArray = new ArrayList<>();
        for (int i = 0; i < rows; i++) {
            firstArray.add(scan.nextLine().split("\\s+"));
        }
        for (int i = 0; i < rows; i++) {
            secondArray.add(scan.nextLine().split("\\s+"));
        }

        for (int i = 0; i < rows; i++) {
            firstArray.set(i, RemoveEmptyEntries(firstArray.get(i)));
            secondArray.set(i, RemoveEmptyEntries(secondArray.get(i)));
        }

        int firstRowLengthCombined = firstArray.get(0).length + secondArray.get(0).length;
        boolean doArrayssFit = true;
        for (int i = 1; i < rows; i++) {
            if (firstArray.get(i).length + secondArray.get(i).length != firstRowLengthCombined) {
                doArrayssFit = false;
                break;
            }
        }

        for (int i = 0; i < rows; i++) {
              reverseStringArray(secondArray.get(i));
        }

        if (doArrayssFit) {
            for (int i = 0; i < rows; i++) {
                ArrayList<String> output = new ArrayList<>();
                output.add(String.join(", ", firstArray.get(i)));
                output.add(String.join(", ", secondArray.get(i)));
                System.out.println("[" + String.join(", ", output) + "]");
            }
        } else {
            int totalCells = 0;
            for (int i = 0; i < rows; i++) {
                totalCells += firstArray.get(i).length;
                totalCells += secondArray.get(i).length;
            }

            System.out.println("The total number of cells is: " + totalCells);
        }
    }

    private static String[] RemoveEmptyEntries(String[] array) {
        ArrayList<String> result = new ArrayList<>();
        for (String s : array) {
            if (s.compareTo("") != 0) {
                result.add(s);
            }
        }

        return result.toArray(new String[result.size()]);
    }

    private static void reverseStringArray(String[] array) {
        for(int i = 0; i < array.length / 2; i++)
        {
            String temp = array[i];
            array[i] = array[array.length - i - 1];
            array[array.length - i - 1] = temp;
        }
    }
}
