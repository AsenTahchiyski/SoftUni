import java.text.MessageFormat;

public class PrintYourHometown {
    public static void main(String[] args) {
        String hometown = "Smolyan";
        String newLine = System.getProperty("line.separator");
        String tabulation = "\t";
        System.out.println(MessageFormat.format("My hometown is {0}{1}{2}.", newLine, tabulation + tabulation, hometown));
    }
}
