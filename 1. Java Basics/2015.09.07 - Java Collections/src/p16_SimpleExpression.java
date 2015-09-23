import java.math.BigDecimal;
import java.util.Scanner;
import java.util.Stack;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class p16_SimpleExpression {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String expression = scan.nextLine();
        Pattern patternNumbers = Pattern.compile("\\d+[,.]?\\d*");
        Pattern patternOperators = Pattern.compile("[+-]");
        Matcher numberMatcher = patternNumbers.matcher(expression);
        Matcher operatorMatcher = patternOperators.matcher(expression);
        Stack<String> expressionStack = new Stack<>();
        while(numberMatcher.find()) {
            expressionStack.push(numberMatcher.group());
            if (operatorMatcher.find()) {
                expressionStack.push(operatorMatcher.group());
            } else {
                break;
            }
        }

        Stack<String> reversedStack = reverseStack(expressionStack);

        while(reversedStack.size() > 1) {
            BigDecimal firstNumber = new BigDecimal(reversedStack.pop());
            String operator = reversedStack.pop();
            BigDecimal secondNumber = new BigDecimal(reversedStack.pop());
            BigDecimal tempResult = performOperation(firstNumber, operator, secondNumber);
            reversedStack.push(String.valueOf(tempResult));
        }

        System.out.println(new BigDecimal(reversedStack.pop()).toPlainString());
    }

    private static Stack<String> reverseStack(Stack<String> expressionStack) {
        Stack<String> reversed = new Stack<>();
        while(!expressionStack.empty()) {
            reversed.push(expressionStack.pop());
        }

        return reversed;
    }

    private static BigDecimal performOperation(BigDecimal firstNumber, String operator, BigDecimal secondNumber) {
        switch (operator) {
            case "+": return firstNumber.add(secondNumber);
            case "-": return firstNumber.subtract(secondNumber);
            default: return BigDecimal.ZERO;
        }
    }
}
