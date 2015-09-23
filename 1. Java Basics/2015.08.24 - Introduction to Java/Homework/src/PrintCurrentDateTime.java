import java.text.MessageFormat;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class PrintCurrentDateTime {
    public static void main(String[] args) {
        String currentTime = LocalDateTime.now().format(DateTimeFormatter.ISO_LOCAL_TIME);
        String currentDate = LocalDateTime.now().format(DateTimeFormatter.ISO_LOCAL_DATE);
        System.out.println(MessageFormat.format("Current date is {0}\nCurrent time is {1}", currentDate, currentTime));
    }
}
