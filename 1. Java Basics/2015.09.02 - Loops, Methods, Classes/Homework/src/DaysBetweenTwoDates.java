import java.util.Scanner;
import org.joda.time.DateTime;
import org.joda.time.Days;
import org.joda.time.LocalDate;
import org.joda.time.format.DateTimeFormat;
import org.joda.time.format.DateTimeFormatter;

public class DaysBetweenTwoDates {
    public static void main(String[] args) {
        System.out.print("Enter first date : ");
        Scanner scan = new Scanner(System.in);
        String firstDate = scan.nextLine();
        System.out.print("Enter second date : ");
        String secondDate = scan.nextLine();

        // Formatter
        DateTimeFormatter dateStringFormat = DateTimeFormat
                .forPattern("dd-MM-yyyy");
        DateTime firstTime = dateStringFormat.parseDateTime(firstDate);
        DateTime secondTime = dateStringFormat.parseDateTime(secondDate);
        int days = Days.daysBetween(new LocalDate(firstTime),
                new LocalDate(secondTime)).getDays();
        System.out.println("Days between the two dates " + days);
    }
}