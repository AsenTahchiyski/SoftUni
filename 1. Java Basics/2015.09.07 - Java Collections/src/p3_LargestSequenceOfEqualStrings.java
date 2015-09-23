import java.util.HashMap;
import java.util.Scanner;

public class p3_LargestSequenceOfEqualStrings {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] sequences = scan.nextLine().split("\\s+");
        HashMap<String, Integer> data = new HashMap<>();
        int maxElements = 0;
        String element = "";
        for (String sequence : sequences) {
            if (!data.containsKey(sequence)) {
                data.put(sequence, 0);
            }
            data.put(sequence, data.get(sequence) + 1);
            if (maxElements < data.get(sequence) + 1) {
                maxElements = data.get(sequence) + 1;
                element = sequence;
            }
        }
        if (element != "") {
            for (int i = 0; i < data.get(element); i++) {
                System.out.print(element + " ");
            }
        }
    }
}
