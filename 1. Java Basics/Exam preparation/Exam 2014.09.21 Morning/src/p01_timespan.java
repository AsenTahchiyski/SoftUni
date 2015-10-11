import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class p01_timespan {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String dateStop = scan.nextLine();
        String dateStart = scan.nextLine();

        //HH converts hour in 24 hours format (0-23), day calculation
        SimpleDateFormat format = new SimpleDateFormat("HH:mm:ss");

        Date d1 = null;
        Date d2 = null;

        try {
            d1 = format.parse(dateStart);
            d2 = format.parse(dateStop);

            //in milliseconds
            long diff = d2.getTime() - d1.getTime();

            long diffSeconds = diff / 1000 % 60;
            long diffMinutes = diff / (60 * 1000) % 60;
            long diffHours = diff / (60 * 60 * 1000);

            System.out.print(diffHours + ":");
            System.out.printf("%02d:", diffMinutes);
            System.out.printf("%02d", diffSeconds);

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}