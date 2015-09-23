import java.util.ArrayList;
import java.util.Scanner;

public class p9_CombineListsOfLetters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] firstInput = scan.nextLine().split("\\s+");
        ArrayList<Character> list1 = new ArrayList<>();
        for (String s : firstInput) {
            for (char c : s.toCharArray()) {
                list1.add(c);
            }
        }
        String[] secondInput = scan.nextLine().split("\\s+");
        ArrayList<Character> list2 = new ArrayList<>();
        for (String s : secondInput) {
            for (char c : s.toCharArray()) {
                list2.add(c);
            }
        }
        ArrayList<Character> output = new ArrayList<>();
        output.addAll(list1);
        for (Character character : list2) {
            if (!list1.contains(character)) {
                output.add(character);
            }
        }

        for (Character character : output) {
            System.out.print(character + " ");
        }
    }
}
