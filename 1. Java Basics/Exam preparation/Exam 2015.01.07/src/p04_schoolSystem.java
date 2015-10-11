import java.util.ArrayList;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class p04_schoolSystem {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int lines = Integer.parseInt(scan.nextLine());
        TreeMap<String, TreeMap<String, ArrayList<Double>>> data = new TreeMap<>();
        for (int i = 0; i < lines; i++) {
            String[] line = scan.nextLine().split(" ");
            String fullName = line[0] + " " + line[1];
            String course = line[2];
            double grade = Double.parseDouble(line[3]);

            if (!data.containsKey(fullName)) {
                data.put(fullName, new TreeMap<>());
            }

            if (!data.get(fullName).containsKey(course)) {
                data.get(fullName).put(course, new ArrayList<>());
            }

            data.get(fullName).get(course).add(grade);
        }

        for (Map.Entry<String, TreeMap<String, ArrayList<Double>>> student : data.entrySet()) {
            boolean isFirst = true;
            System.out.print(student.getKey() + ": [");
            TreeMap<String, ArrayList<Double>> courseData = student.getValue();
            for (Map.Entry<String, ArrayList<Double>> course : courseData.entrySet()) {
                if (!isFirst) {
                    System.out.print(", ");
                }
                System.out.printf("%s - %.2f", course.getKey(),
                        course.getValue().stream().mapToDouble(g -> g).average().orElse(0));
                isFirst = false;
            }

            System.out.println("]");
        }
    }
}
