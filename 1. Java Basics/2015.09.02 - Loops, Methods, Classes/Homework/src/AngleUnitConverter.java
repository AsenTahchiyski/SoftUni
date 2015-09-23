import java.util.Scanner;

public class AngleUnitConverter {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.print("Enter number of conversions to be made: ");
        int numberOfConversions = scan.nextInt();
        for (int i = 0; i < numberOfConversions; i++) {
            System.out.printf(
                    "Enter %d value to be converted + type of value (deg / rad): ",
                    i + 1);
            double valueToConvert = Double.parseDouble(scan.next());
            String commandType = scan.next();
            switch (commandType) {
                case "deg":
                    System.out.println(convertGradToRad(valueToConvert));
                    break;
                case "rad":
                    System.out.println(convertRadToGrad(valueToConvert));
                    break;
                default:
                    System.out.println("Invalid command parameter, try again.");
                    break;
            }
        }
    }

    private static String convertGradToRad(double grad) {
        return String.format("%.6f rad", grad * Math.PI / 180);
    }

    private static String convertRadToGrad (double rad) {
        return String.format("%.6f deg", rad * 180 / Math.PI);
    }
}
