import java.util.Scanner;

public class p02_addingAngles {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalAngles = Integer.parseInt(scan.nextLine());
        String[] angles = scan.nextLine().split(" ");
        boolean comboFound = false;
        for (int i = 0; i < totalAngles; i++) {
            for (int j = i + 1; j < totalAngles; j++) {
                for (int k = j + 1; k < totalAngles; k++) {
                    if (i != j && i != k && k != j) {
                        int angle1 = Integer.parseInt(angles[i]);
                        int angle2 = Integer.parseInt(angles[j]);
                        int angle3 = Integer.parseInt(angles[k]);
                        int sum = angle1 + angle2 + angle3;
                        if (sum % 360 == 0) {
                            System.out.printf("%d + %d + %d = %d degrees",
                                    angle1, angle2, angle3, sum).println();
                            comboFound = true;
                        }
                    }
                }
            }
        }

        if (!comboFound) {
            System.out.println("No");
        }
    }
}

