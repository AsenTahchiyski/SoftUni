import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class SumNumbersFromTextFile {
    public static void main(String[] args) {
        String filePath = "Numbers1.txt";
        int sum = 0;
        try {
            for (String line : Files.readAllLines(Paths.get(filePath))) {
                int number = Integer.parseInt(line);
                sum += number;
            }
        } catch (IOException e) {
            System.out.println("Error, file not found.");
            return;
        }
        System.out.println(sum);
    }
}
