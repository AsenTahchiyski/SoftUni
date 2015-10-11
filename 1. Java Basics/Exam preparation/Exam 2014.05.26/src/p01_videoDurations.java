import java.util.Scanner;

public class p01_videoDurations {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        int[] totalTime = new int[2];
        while (line.compareTo("End") != 0) {
            String[] time = line.split(":");
            int hours = Integer.parseInt(time[0]);
            int minutes = Integer.parseInt(time[1]);
            totalTime[0] += hours;
            totalTime[1] += minutes;
            line = scan.nextLine();
        }

        totalTime[0] += totalTime[1] / 60;
        totalTime[1] %= 60;
        System.out.printf("%d:%02d", totalTime[0], totalTime[1]);
    }
}
