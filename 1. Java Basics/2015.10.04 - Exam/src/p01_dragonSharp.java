import java.util.Scanner;

public class p01_dragonSharp {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalLines = Integer.parseInt(scan.nextLine());
        boolean anythingElse = false;
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < totalLines; i++) {
            String line = scan.nextLine();
            if (!line.contains("\"") || line.charAt(line.length() - 1) != ';' ||
                    line.charAt(line.length() - 2) != '"' || line.indexOf("\"") == line.length() - 1) {
                System.out.println("Compile time error @ line " + (i + 1));
                return;
            }

            int stringStart = line.indexOf('"');
            if (stringStart == line.length() - 2) {
                return;
            }
            String command = line.substring(0, stringStart);
            String toPrint = line.substring(stringStart + 1, line.length() - 2);
            String[] lineParams = command.split(" ");
            if (lineParams[0].equals("if")) {
                if (anythingElse) {
                    anythingElse = false;
                }

                String condition = lineParams[1];
                boolean check = isConditionTrue(condition);
                if (check) {
                    String action = lineParams[2];
                    if (action.equals("loop")) {
                        int loops = Integer.parseInt(lineParams[3]);
                        for (int j = 0; j < loops; j++) {
                            output.append(toPrint).append("\n");
                        }
                    } else if (action.equals("out")) {
                        output.append(toPrint).append("\n");
                    }
                } else if (!check) {
                    anythingElse = true;
                    continue;
                }
            } else if(lineParams[0].equals("else")) {
                if (!anythingElse) {
                    continue;
                }

                String action = lineParams[1];
                if (action.equals("out")) {
                    output.append(toPrint).append("\n");
                } else if (action.equals("loop")) {
                    Integer loops = Integer.parseInt(lineParams[2]);
                    for (int j = 0; j < loops; j++) {
                        output.append(toPrint).append("\n");
                    }
                }

                anythingElse = false;
            }
        }

        System.out.println(output);
    }

    private static boolean isConditionTrue(String input) {
        String condition = input.substring(1, input.length() - 1);
        if (condition.contains("==")) {
            String[] numbers = condition.split("==");
            int firstNumber = Integer.parseInt(numbers[0]);
            int secNumber = Integer.parseInt(numbers[1]);
            if (firstNumber == secNumber) {
                return true;
            } else {
                return false;
            }
        } else if (condition.contains(">")) {
            String[] numbers = condition.split(">");
            int firstNumber = Integer.parseInt(numbers[0]);
            int secNumber = Integer.parseInt(numbers[1]);
            if (firstNumber > secNumber) {
                return true;
            } else {
                return false;
            }
        } else if (condition.contains("<")) {
            String[] numbers = condition.split("<");
            int firstNumber = Integer.parseInt(numbers[0]);
            int secNumber = Integer.parseInt(numbers[1]);
            if (firstNumber < secNumber) {
                return true;
            } else {
                return false;
            }
        }

        return false;
    }
}
