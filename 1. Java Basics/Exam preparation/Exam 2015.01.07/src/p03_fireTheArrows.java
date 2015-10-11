import java.util.Scanner;

public class p03_fireTheArrows {
    private static boolean hasMoved;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int rows = Integer.parseInt(scan.nextLine());
        char[][] matrix = new char[rows][];
        for (int i = 0; i < rows; i++) {
            matrix[i] = scan.nextLine().toCharArray();
        }

        do {
            hasMoved = false;
            for (int row = 0; row < matrix.length; row++) {
                for (int col = 0; col < matrix[row].length; col++) {
                    if (matrix[row][col] != 'o') {
                        performMove(row, col, matrix);
                    }
                }
            }

        } while(hasMoved);

        print(matrix);
    }

    private static void performMove(int row, int col, char[][] matrix) {
        char move = matrix[row][col];
        switch (move) {
            case '>':
                if (col + 1 < matrix[row].length && matrix[row][col + 1] == 'o') {
                    matrix[row][col + 1] = '>';
                    matrix[row][col] = 'o';
                    hasMoved = true;
                }

                return;
            case 'v':
                if (row + 1 < matrix.length && matrix[row + 1][col] == 'o') {
                    matrix[row + 1][col] = 'v';
                    matrix[row][col] = 'o';
                    hasMoved = true;
                }

                return;
            case '<':
                if (col - 1 >= 0 && matrix[row][col - 1] == 'o') {
                    matrix[row][col - 1] = '<';
                    matrix[row][col] = 'o';
                    hasMoved = true;
                }

                return;
            case '^':
                if (row - 1 >= 0 && matrix[row - 1][col] == 'o') {
                    matrix[row - 1][col] = '^';
                    matrix[row][col] = 'o';
                    hasMoved = true;
                }

                return;
            default:
                hasMoved = false;
                return;
        }
    }

    private static void print(char[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col]);
            }

            System.out.println();
        }
    }
}
