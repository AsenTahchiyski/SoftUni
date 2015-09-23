import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class p2_SequencesOfEqualStrings {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] sequences = scan.nextLine().split("\\s+");
        HashMap<String, Integer> data = new HashMap<>();
        for (String sequence : sequences) {
            if (!data.containsKey(sequence)) {
                data.put(sequence, 0);
            }
            data.put(sequence, data.get(sequence) + 1);
        }
        for (Map.Entry<String, Integer> set : data.entrySet()) {
            for (int i = 0; i < set.getValue(); i++) {
                System.out.print(set.getKey() + " ");
            }
            System.out.println();
        }
    }
}
