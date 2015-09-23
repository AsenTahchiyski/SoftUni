import java.text.MessageFormat;
import java.util.Scanner;

public class SortArrayOfStrings {
    public static void main(String[] args) {
        System.out.print("Enter a number of strings to be sorted: ");
        Scanner input = new Scanner(System.in);
        int numberOfStrings = input.nextInt();
        String[] stringArray = new String[numberOfStrings];
        System.out.println(MessageFormat.format("Enter {0} strings to be sorted:", numberOfStrings));
        for (int i = 0; i < numberOfStrings; i++) {
            System.out.print(MessageFormat.format("String {0}: ", i + 1));
            stringArray[i] = input.next();
        }
        stringArray = InsertionSort(stringArray);
        System.out.println("Strings after sorting:");
        System.out.println(String.join(", ", stringArray));
    }

    private static String[] InsertionSort(String[] arrayToSort) {
        arrayToSort = arrayToSort.clone();
        for (int i = 1; i < arrayToSort.length; i++) {
            for (int j = i; j >= 0; j--) {
                while (j > 0 && arrayToSort[j - 1].compareTo(arrayToSort[j]) > 0) {
                    String temp = arrayToSort[j];
                    arrayToSort[j] = arrayToSort[j-1];
                    arrayToSort[j-1] = temp;
                }
            }
        }
        return arrayToSort;
    }
}
