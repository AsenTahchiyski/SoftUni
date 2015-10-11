import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

// Author's solution is wrong, the numbers should be non-recurring by description of the problem. This is the right way:
public class p03_biggest3primes {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        Pattern pattern = Pattern.compile("-?\\d+");
        Matcher matcher = pattern.matcher(line);
        TreeMap<Integer, Integer> primeNumbers = new TreeMap<>(Collections.reverseOrder());
        while (matcher.find()) {
            int number = Integer.parseInt(matcher.group());
            if (isPrime(number)) {
                if (!primeNumbers.containsKey(number)) {
                    primeNumbers.put(number, 0);
                }

                primeNumbers.put(number, primeNumbers.get(number) + 1);
            }
        }

        int result = 0;
        int counter = 0;
        for (Map.Entry<Integer, Integer> entry : primeNumbers.entrySet()) {
            if (entry.getValue() == 1) {
                result += entry.getKey();
                counter++;
            }

            if (counter == 3) { break; }
        }

        if (counter < 3) {
            System.out.println("No");
        } else {
            System.out.println(result);
        }
    }

    private static boolean isPrime(int n) {
        if (n < 0) { return false; }
        //check if n is a multiple of 2
        if (n%2==0) return false;
        //if not, then just check the odds
        for(int i=3;i*i<=n;i+=2) {
            if(n%i==0)
                return false;
        }
        return true;
    }
}
