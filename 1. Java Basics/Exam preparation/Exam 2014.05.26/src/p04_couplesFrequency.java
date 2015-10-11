import java.util.*;

public class p04_couplesFrequency {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] numbers = scan.nextLine().split(" ");
        ArrayList<String> couples = new ArrayList<>();
        for (int i = 0; i < numbers.length - 1; i++) {
            couples.add(numbers[i] + " " + numbers[i + 1]);
        }

        LinkedHashMap<String, Integer> couplesFrequency = new LinkedHashMap<>();
        for (String couple : couples) {
            if (!couplesFrequency.containsKey(couple)) {
                couplesFrequency.put(couple, 0);
            }

            couplesFrequency.put(couple, couplesFrequency.get(couple) + 1);
        }

        int totalCouples = couples.size();
        List<Map.Entry<String, Integer>> sortedByValue = entriesSortedByValues(couplesFrequency);
        for (Map.Entry<String, Integer> entry : sortedByValue) {
            System.out.printf("%s -> %.2f", entry.getKey(), (double)entry.getValue() * 100 / totalCouples);
            System.out.println("%");
        }
    }

    static <K,V extends Comparable<? super V>>
    List<Map.Entry<K, V>> entriesSortedByValues(Map<K,V> map) {

        List<Map.Entry<K,V>> sortedEntries = new ArrayList<Map.Entry<K,V>>(map.entrySet());

        Collections.sort(sortedEntries,
                new Comparator<Map.Entry<K,V>>() {
                    @Override
                    public int compare(Map.Entry<K,V> e1, Map.Entry<K,V> e2) {
                        return e2.getValue().compareTo(e1.getValue());
                    }
                }
        );

        return sortedEntries;
    }
}
