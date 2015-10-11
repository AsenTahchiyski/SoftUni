import java.util.ArrayList;
import java.util.Scanner;

public class p01_pyramid {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalLines = Integer.parseInt(scan.nextLine());
        ArrayList<Integer[]> lines = new ArrayList<>();
        for (int i = 0; i < totalLines; i++) {
            String[] line = scan.nextLine().split("\\s+");
            Integer[] lineInt = removeEmptyEntriesAndParseToInt(line);
            lines.add(lineInt);
        }

        ArrayList<Integer> result = new ArrayList<>();
        int previous = lines.get(0)[0];
        result.add(previous);
        int numberToAdd = previous;
        for (int i = 1; i < totalLines; i++) {
            int diff = Integer.MAX_VALUE;
            for (int num : lines.get(i)) {
                if (num > previous && num - previous < diff) {
                    numberToAdd = num;
                    diff = num - previous;
                }
            }

            if (numberToAdd != previous) {
                result.add(numberToAdd);
                previous = numberToAdd;
            }
        }

        for (int i = 0; i < result.size() - 1; i++) {
            System.out.print(result.get(i) + ", ");
        }

        System.out.println(result.get(result.size() - 1));
    }

    private static Integer[] removeEmptyEntriesAndParseToInt(String[] array) {
        ArrayList<Integer> result = new ArrayList<>();
        for (String s : array) {
            if (!s.equals("")) {
                result.add(Integer.parseInt(s));
            }
        }

        return result.toArray(new Integer[result.size()]);
    }
}
