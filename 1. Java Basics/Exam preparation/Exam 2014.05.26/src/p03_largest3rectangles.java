import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p03_largest3rectangles {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        Pattern pattern = Pattern.compile("\\d+");
        Matcher matcher = pattern.matcher(line);
        ArrayList<int[]> rectangles = new ArrayList<>();
        int[] temp = {-1, -1};
        while (matcher.find()) {
            if (temp[0] == -1) {
                temp[0] = Integer.parseInt(matcher.group());
            } else if (temp[1] == -1) {
                temp[1] = Integer.parseInt(matcher.group());
                rectangles.add(temp.clone());
                temp[0] = -1;
                temp[1] = -1;
            }
        }

        int maxTotalArea = 0;
        for (int i = 0; i < rectangles.size() - 2; i++) {
            int firstArea = rectangles.get(i)[0] * rectangles.get(i)[1];
            int secArea = rectangles.get(i + 1)[0] * rectangles.get(i + 1)[1];
            int thirdArea = rectangles.get(i + 2)[0] * rectangles.get(i + 2)[1];
            int currentAreaSum = firstArea + secArea + thirdArea;
            if (currentAreaSum > maxTotalArea) {
                maxTotalArea = currentAreaSum;
            }
        }

        System.out.println(maxTotalArea);
    }
}
