import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p01_gandalfStash {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int startMood = Integer.parseInt(scan.nextLine());
        String allFood = scan.nextLine();
        Pattern pattern = Pattern.compile("[a-zA-Z]+");
        Matcher matcher = pattern.matcher(allFood);
        while(matcher.find()) {
            String food = matcher.group();
            int foodHappiness = getFoodHappiness(food);
            startMood += foodHappiness;
        }

        System.out.println(startMood);
        System.out.println(getMood(startMood));
    }

    private static int getFoodHappiness(String food) {
        switch (food.toLowerCase()) {
            case "cram": return 2;
            case "lembas": return 3;
            case "apple": return 1;
            case "melon": return 1;
            case "honeycake": return 5;
            case "mushrooms": return -10;
            default: return -1;
        }
    }

    private static String getMood(int happiness) {
        if (happiness < -5) {
            return "Angry";
        } else if (happiness >= -5 && happiness <= 0) {
            return "Sad";
        } else if (happiness > 0 && happiness <= 15) {
            return "Happy";
        } else {
            return "Special JavaScript mood";
        }
    }
}
