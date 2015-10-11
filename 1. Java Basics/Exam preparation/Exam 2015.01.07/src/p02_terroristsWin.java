import java.util.ArrayList;
import java.util.Scanner;

public class p02_terroristsWin {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        char[] input = scan.nextLine().toCharArray();
        boolean hasBegun = false;
        int lastStartIndex = -1;
        ArrayList<Character> bomb = new ArrayList<>();
        for (int i = 0; i < input.length; i++) {
            if (input[i] == '|') {
                if (!hasBegun) {
                    hasBegun = true;
                    lastStartIndex = i;
                } else {
                    hasBegun = false;
                    int blast = 0;
                    for (int j = lastStartIndex + 1; j < i; j++) {
                        bomb.add(input[j]);
                        blast += input[j];
                    }

                    int blastRange = blast % 10;
                    int blastStart = lastStartIndex - blastRange >= 0 ? lastStartIndex - blastRange : 0;
                    int blastEnd = i + blastRange < input.length ? i + blastRange : input.length - 1;
                    for (int j = blastStart; j <= blastEnd; j++) {
                        input[j] = '.';
                    }
                }
            }
        }

        for (char c : input) {
            System.out.print(c);
        }
    }
}
