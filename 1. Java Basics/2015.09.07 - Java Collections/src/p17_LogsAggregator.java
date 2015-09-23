import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class p17_LogsAggregator {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        TreeMap<String, TreeMap<String, Integer>> data = new TreeMap<>();
        int numberOfLogs = Integer.parseInt(scan.nextLine());
        for (int i = 0; i < numberOfLogs; i++) {
            String[] parameters = scan.nextLine().split("\\s+");
            String ip = parameters[0];
            String username = parameters[1];
            int duration = Integer.parseInt(parameters[2]);

            if (!data.containsKey(username)) {
                TreeMap<String, Integer> visits = new TreeMap<>();
                visits.put(ip, duration);
                data.put(username, visits);
            } else {
                if (!data.get(username).containsKey(ip)) {
                    data.get(username).put(ip, duration);
                } else {
                    data.get(username).put(ip, data.get(username).get(ip) + duration);
                }
            }
        }

        for (Map.Entry<String, TreeMap<String, Integer>> user : data.entrySet()) {
            System.out.print(user.getKey() + ": ");
            int totalDuration = 0;
            for (Integer time : user.getValue().values()) {
                totalDuration += time;
            }
            System.out.print(totalDuration);
            System.out.println(" [" + String.join(", ", user.getValue().keySet()) + "]");
        }
    }
}
