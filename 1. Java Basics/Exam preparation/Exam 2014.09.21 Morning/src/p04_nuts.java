import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class p04_nuts {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalOrders = Integer.parseInt(scan.nextLine());
        TreeMap<String, LinkedHashMap<String, Integer>> data = new TreeMap<>();
        for (int i = 0; i < totalOrders; i++) {
            String[] lineParams = scan.nextLine().split("\\s+");
            String company = lineParams[0];
            String nutsType = lineParams[1];
            int amount = Integer.parseInt(lineParams[2].substring(0, lineParams[2].length() - 2));

            if (!data.containsKey(company)) {
                data.put(company, new LinkedHashMap<>());
            }

            if (!data.get(company).containsKey(nutsType)) {
                data.get(company).put(nutsType, 0);
            }

            data.get(company).put(nutsType, data.get(company).get(nutsType) + amount);
        }

        for (String company : data.keySet()) {
            System.out.print(company + ": ");
            LinkedHashMap<String, Integer> nuts = data.get(company);
            StringBuilder output = new StringBuilder();
            for (Map.Entry<String, Integer> pair : nuts.entrySet()) {
                output.append(pair.getKey() + "-" + pair.getValue() + "kg, ");
            }

            System.out.println(output.substring(0, output.length() - 2));
        }
    }
}
