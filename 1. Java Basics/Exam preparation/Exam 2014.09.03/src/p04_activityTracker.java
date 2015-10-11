import java.util.Scanner;
import java.util.TreeMap;

public class p04_activityTracker {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalEntries = Integer.parseInt(scan.nextLine());
        TreeMap<Integer, TreeMap<String, Integer>> data = new TreeMap<>();
        for (int i = 0; i < totalEntries; i++) {
            String[] lineData = scan.nextLine().split(" ");
            String[] date = lineData[0].split("/");
            int month = Integer.parseInt(date[1]);
            String user = lineData[1];
            int distance = Integer.parseInt(lineData[2]);

            if (!data.containsKey(month)) {
                data.put(month, new TreeMap<>());
            }

            if (!data.get(month).containsKey(user)) {
                data.get(month).put(user, 0);
            }

            data.get(month).put(user, data.get(month).get(user) + distance);
        }

        for (Integer month : data.keySet()) {
            StringBuilder output = new StringBuilder();
            output.append(month + ": ");
            TreeMap<String, Integer> monthData = data.get(month);
            for (String s : monthData.keySet()) {
                output.append(s + "(" + monthData.get(s) + "), ");
            }

            System.out.println(output.substring(0, output.length() - 2));
        }
    }
}
