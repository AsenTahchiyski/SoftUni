import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p04_userLogs {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Pattern pattern = Pattern.compile("IP=([0-9A-Fa-f:\\.]+).+user=([a-zA-Z0-9]+)");
        String line = scan.nextLine();
        TreeMap<String, LinkedHashMap<String, Integer>> data = new TreeMap<>();
        while(line.compareTo("end") != 0) {
            Matcher matcher = pattern.matcher(line);
            while(matcher.find()) {
                String username = matcher.group(2);
                if (!data.containsKey(username)) {
                    data.put(username, new LinkedHashMap<>());
                }

                String ip = matcher.group(1);
                if (!data.get(username).containsKey(ip)) {
                    data.get(username).put(ip, 0);
                }

                data.get(username).put(ip, data.get(username).get(ip) + 1);
            }

            line = scan.nextLine();
        }

        for (Map.Entry<String, LinkedHashMap<String, Integer>> user : data.entrySet()) {
            System.out.println(user.getKey() + ":");
            HashMap<String, Integer> ipData = user.getValue();
            ArrayList<String> ipOutput = new ArrayList<>();
            for (Map.Entry<String, Integer> ip : ipData.entrySet()) {
                ipOutput.add(ip.getKey() + " => " + ip.getValue());
            }

            System.out.println(String.join(", ", ipOutput) + ".");
        }
    }
}
