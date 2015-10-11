import java.text.MessageFormat;
import java.util.*;

public class p03_examScore {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        TreeMap<Integer, ArrayList<Student>> studentsByScore =
                new TreeMap<>();

        scan.nextLine();
        scan.nextLine();
        scan.nextLine();
        String line = scan.nextLine();

        while(!line.contains("-")) {
            String[] data = line.split("\\|", -1);
            data = removeEmptyEntriesMethodBecauseJavaSucksAss(data);
            String name = data[0];
            int score = Integer.parseInt(data[1]);
            double grade = Double.parseDouble(data[2]);

            if (!studentsByScore.containsKey(score)) {
                studentsByScore.put(score, (new ArrayList<>()));
            }

            Student student = new Student();
            student.setName(name);
            student.setScore(score);
            student.setGrade(grade);
            studentsByScore.get(score).add(student);

            line = scan.nextLine();
        }

        for (ArrayList<Student> names : studentsByScore.values()) {
            names.sort((s1, s2) -> s1.getName().compareTo(s2.getName()));
        }

        double averageGrade;
        ArrayList<String> names;
        for (Map.Entry<Integer, ArrayList<Student>> pair : studentsByScore.entrySet()) {
            names = new ArrayList<>();
            double gradesTotal = 0;
            for (Student student : pair.getValue()) {
                names.add(student.getName());
                gradesTotal += student.getGrade();
            }
            averageGrade = gradesTotal / pair.getValue().size();

            System.out.println(MessageFormat.format("{0} -> [{1}]; avg={2,number,0.00}",
                            pair.getKey(), String.join(", ", names), averageGrade));
        }
    }

    private static String[] removeEmptyEntriesMethodBecauseJavaSucksAss(String[] array) {
        ArrayList<String> result = new ArrayList<>();
        for (String s : array) {
            if (s.length() > 0) {
                result.add(s.trim());
            }
        }
        String[] output = new String[result.size()];
        return result.toArray(output);
    }
}

class Student {
    private String name;
    private int score;
    private double grade;

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getScore() {
        return this.score;
    }

    public void setScore(int score) {
        this.score = score;
    }

    public double getGrade() {
        return this.grade;
    }

    public void setGrade(double grade) {
        this.grade = grade;
    }

    @Override
    public String toString() {
        return this.getName();
    }
}

