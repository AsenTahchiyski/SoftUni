import java.util.ArrayList;
import java.util.Scanner;

public class p03_labyrinthDash {
    private static int lives = 3;
    private static int currentRow = 0;
    private static int currentCol = 0;
    private static int totalMoves = 0;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int rows = Integer.parseInt(scan.nextLine());
        ArrayList<char[]> labyrinth = new ArrayList<>();
        for (int i = 0; i < rows; i++) {
            labyrinth.add(scan.nextLine().toCharArray());
        }

        char[] moves = scan.nextLine().toCharArray();
        for (char move : moves) {
            int livesBefore = lives;
            if (!processMove(move, labyrinth) && lives <= 0) {
                System.out.println("Total moves made: " + totalMoves);
                return;
            }

            if (livesBefore < lives) {
                labyrinth.get(currentRow)[currentCol] = '.';
            }
        }

        System.out.println("Total moves made: " + totalMoves);
    }

    private static boolean processMove(char direction, ArrayList<char[]> labyrinth) {
        switch (direction) {
            case 'v':
                if (validatePosition(currentRow + 1, currentCol, labyrinth)) {
                    if (getOutcome(labyrinth.get(currentRow + 1)[currentCol])) {
                        if (lives > 0) {
                            currentRow++;
                            return true;
                        }
                    }
                }
                return false;
            case '<':
                if (validatePosition(currentRow, currentCol - 1, labyrinth)) {
                    if (getOutcome(labyrinth.get(currentRow)[currentCol - 1])) {
                        if (lives > 0) {
                            currentCol--;
                            return true;
                        }
                    }
                }
                return false;
            case '^':
                if (validatePosition(currentRow - 1, currentCol, labyrinth)) {
                    if (getOutcome(labyrinth.get(currentRow - 1)[currentCol])) {
                        if (lives > 0) {
                            currentRow--;
                            return true;
                        }
                    }
                }
                return false;
            case '>':
                if (validatePosition(currentRow, currentCol + 1, labyrinth)) {
                    if (getOutcome(labyrinth.get(currentRow)[currentCol + 1])) {
                        if (lives > 0) {
                            currentCol++;
                            return true;
                        }
                    }
                }
                return false;
            default:
                return false;
        }
    }

    private static boolean getOutcome(char cell) {
        switch(cell) {
            case '_':
            case '|':
                System.out.println("Bumped a wall.");
                return false;
            case '@':
            case '#':
            case '*':
                lives--;
                if (lives > 0) {
                    System.out.println("Ouch! That hurt! Lives left: " + lives);
                    totalMoves++;
                    return true;
                } else if (lives == 0) {
                    System.out.println("Ouch! That hurt! Lives left: " + lives);
                    totalMoves++;
                    System.out.println("No lives left! Game Over!");
                    return false;
                }
            case '$':
                lives++;
                totalMoves++;
                System.out.println("Awesome! Lives left: " + lives);
                cell = '.';
                return true;
            case ' ':
                System.out.println("Fell off a cliff! Game Over!");
                totalMoves++;
                lives = 0;
                return false;
            case '.':
                System.out.println("Made a move!");
                totalMoves++;
                return true;
            default: return false;
        }
    }

    private static boolean validatePosition(int row, int col, ArrayList<char[]> labyrinth) {
        if (row < 0 || row > labyrinth.size() - 1 ||
                col < 0 || col > labyrinth.get(row).length - 1) {
            lives = 0;
            totalMoves++;
            System.out.println("Fell off a cliff! Game Over!");
            return false;
        }

        return true;
    }
}
