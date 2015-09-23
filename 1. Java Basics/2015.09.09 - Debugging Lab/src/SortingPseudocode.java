//import org.apache.commons.lang3.time.StopWatch;
import java.util.ArrayList;
import java.util.Scanner;

public class SortingPseudocode {

    public static void main(String[] args) throws InterruptedException {
        Scanner scan = new Scanner(System.in);

        String[] numbers = scan.nextLine().replace("[", "").replace("]", "").split(", ");
        ArrayList<Integer> numbersArr = new ArrayList<>();

        for (String number : numbers) {
            numbersArr.add(Integer.parseInt(number));
        }

//        StopWatch stopWatch = new StopWatch();
//        stopWatch.start();

        int lastSwappedIndex = numbersArr.size() - 1;
        int lastCurrentIndex = 0;
        boolean didSwap;
        do {
            didSwap = false;
            for (int i = 0; i < lastSwappedIndex; i++) {
                int first = numbersArr.get(i);
                int second = numbersArr.get(i + 1);
                if (first > second) {
                    int temp = first;
                    numbersArr.set(i, second);
                    numbersArr.set(i + 1, temp);
                    didSwap = true;
                    lastCurrentIndex = i;
                }
            }
            lastSwappedIndex = lastCurrentIndex;
        } while(didSwap);

//        stopWatch.stop();
//        long time = stopWatch.getTime();

        System.out.println(numbersArr);
//        System.out.println(time);
    }
}