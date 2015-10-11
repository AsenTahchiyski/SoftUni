import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class p04_orders {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalOrders = Integer.parseInt(scan.nextLine());
        LinkedHashMap<String, TreeMap<String, Integer>> data = new LinkedHashMap<>();
        for (int i = 0; i < totalOrders; i++) {
            String[] lineParams = scan.nextLine().split("\\s+");
            String customer = lineParams[0];
            int amount = Integer.parseInt(lineParams[1]);
            String product = lineParams[2];

            if (!data.containsKey(product)) {
                data.put(product, new TreeMap<>());
            }

            if (!data.get(product).containsKey(customer)) {
                data.get(product).put(customer, 0);
            }

            data.get(product).put(customer, data.get(product).get(customer) + amount);
        }

        for (String product : data.keySet()) {
            StringBuilder output = new StringBuilder();
            output.append(product + ": ");
            TreeMap<String, Integer> customers = data.get(product);
            for (Map.Entry<String, Integer> entry : customers.entrySet()) {
                output.append(entry.getKey() + " " + entry.getValue() + ", ");
            }

            System.out.println(output.substring(0, output.length() - 2));
        }
    }
}
