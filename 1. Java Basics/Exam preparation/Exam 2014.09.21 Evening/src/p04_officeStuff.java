import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p04_officeStuff {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalOrders = Integer.parseInt(scan.nextLine());
        TreeMap<String, LinkedHashMap<String, Integer>> data = new TreeMap<>();
        Pattern pattern = Pattern.compile("(\\w+) - (\\d+) - (\\w+)");
        for (int i = 0; i < totalOrders; i++) {
            String line = scan.nextLine();
            Matcher matcher = pattern.matcher(line);
            if (!matcher.find()) { continue; }
            String company = matcher.group(1);
            int amount = Integer.parseInt(matcher.group(2));
            String product = matcher.group(3);

            if (!data.containsKey(company)) {
                data.put(company, new LinkedHashMap<>());
            }

            if (!data.get(company).containsKey(product)) {
                data.get(company).put(product, 0);
            }

            data.get(company).put(product, data.get(company).get(product) + amount);
        }

        for (Map.Entry<String, LinkedHashMap<String, Integer>> entry : data.entrySet()) {
            StringBuilder result = new StringBuilder();
            result.append(entry.getKey() + ": ");
            LinkedHashMap<String, Integer> order = entry.getValue();
            for (Map.Entry<String, Integer> set : order.entrySet()) {
                result.append(set.getKey() + "-" + set.getValue() + ", ");
            }

            System.out.println(result.substring(0, result.length() - 2));
        }
    }
}
