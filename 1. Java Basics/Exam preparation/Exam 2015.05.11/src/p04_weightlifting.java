import java.util.ArrayList;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class p04_weightlifting {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int entries = Integer.parseInt(scan.nextLine());
        TreeMap<String, TreeMap<String, Long>> data = new TreeMap<>();
        for (int i = 0; i < entries; i++) {
            String[] lineData = scan.nextLine().split("\\s+");
            String name = lineData[0];
            String exercise = lineData[1];
            long weight = Integer.parseInt(lineData[2]);
            
            if (!data.containsKey(name)) {
                data.put(name, new TreeMap<>());
            }
            
            if (!data.get(name).containsKey(exercise)) {
                data.get(name).put(exercise, Long.valueOf(0));
            }
            
            data.get(name).put(exercise, data.get(name).get(exercise) + weight);
        }

        for (Map.Entry<String, TreeMap<String, Long>> user : data.entrySet()) {
            System.out.print(user.getKey() + " : ");
            TreeMap<String, Long> exercices = user.getValue();
            ArrayList<String> sets = new ArrayList<>();
            for (Map.Entry<String, Long> set : exercices.entrySet()) {
                sets.add(set.getKey() + " - " + set.getValue() + " kg");
            }

            System.out.println(String.join(", ", sets));
        }
    }
}
