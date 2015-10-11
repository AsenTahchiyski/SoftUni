import java.util.ArrayList;
import java.util.Scanner;

public class p03_dragonTrap {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int totalRows = Integer.parseInt(scan.nextLine());
        char[][] matrix = new char[totalRows][];
        for (int i = 0; i < totalRows; i++) {
            String line = scan.nextLine();
            matrix[i] = line.toCharArray();
        }

        int totalChangedCells = 0;
        String command = scan.nextLine();
        while (!command.toLowerCase().equals("end")) {
            int indexClosingBracket = command.indexOf(')');
            String[] coordinatesStr = command.substring(1, indexClosingBracket).split("\\s+");
            int dragonRow = Integer.parseInt(coordinatesStr[0]);
            int dragonCol = Integer.parseInt(coordinatesStr[1]);
            String[] rotationParams = command.substring(indexClosingBracket + 1, command.length()).split("\\s+");
            int radius = Integer.parseInt(rotationParams[1]);
            int divisor = 2 * matrix[0].length + 2 * (totalRows - 2);
            long rotations = Long.parseLong(rotationParams[2]) % 2;// % divisor;
            for (int rotation = 0; rotation < Math.abs(rotations); rotation++) {
                ArrayList<int[]> validCells = new ArrayList<>();
                if (rotations > 0) {
                    validCells = getValidCellsInRangeClockwise(matrix,
                            dragonRow, dragonCol, Math.abs(radius));
                } else if (rotations < 0) {
                    validCells = getValidCellsInRangeCounterClockwise(matrix,
                            dragonRow, dragonCol, Math.abs(radius));
                } else if (rotations == 0) {
                    break;
                }

                if (validCells.size() < 2) {
                    break;
                }
                ArrayList<Character> chars = new ArrayList<>();
                for (int cell = 0; cell < validCells.size(); cell++) {
                    chars.add(matrix[validCells.get(cell)[0]][validCells.get(cell)[1]]);
                }

                for (int cell = 1; cell < validCells.size(); cell++) {
                    char current = matrix[validCells.get(cell)[0]][validCells.get(cell)[1]];
                    matrix[validCells.get(cell)[0]][validCells.get(cell)[1]] = chars.get(cell - 1);
                    if (current != matrix[validCells.get(cell)[0]][validCells.get(cell)[1]]) {
                        totalChangedCells++;
                    }
                }

                char current = matrix[validCells.get(0)[0]][validCells.get(0)[1]];
                matrix[validCells.get(0)[0]][validCells.get(0)[1]] = chars.get(chars.size() - 1);
                if (current != matrix[validCells.get(0)[0]][validCells.get(0)[1]]) {
                    totalChangedCells++;
                }
            }

            command = scan.nextLine();
        }

        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                System.out.print(matrix[i][j]);
            }

            System.out.println();
        }

        System.out.println("Symbols changed: " + totalChangedCells);
    }

    private static boolean isCellValid(int row, int col, char[][] matrix) {
        if (row >= 0 && row < matrix.length) {
            if (col >= 0 && col < matrix[row].length) {
                return true;
            }
        }

        return false;
    }

    private static ArrayList<int[]> getValidCellsInRangeClockwise(char[][] matrix,
                              int centerRow, int centerCol, int radius) {
        ArrayList<int[]> validCells = new ArrayList<>();
        int upperRow = centerRow - radius;
        int lowerRow = centerRow + radius;
        int leftCol = centerCol - radius;
        int rightCol = centerCol + radius;
        // get upper row cells >>
        for (int i = leftCol; i <= rightCol; i++) {
            if (isCellValid(upperRow, i, matrix)) {
                validCells.add(new int[] {upperRow, i});
            }
        }
        // get right col cells vv
        for (int i = upperRow + 1; i < lowerRow; i++) {
            if (isCellValid(i, rightCol, matrix)) {
                validCells.add(new int[] {i, rightCol});
            }
        }

        // get lower row cells <<
        for (int i = rightCol; i >= leftCol; i--) {
            if (isCellValid(lowerRow, i, matrix)) {
                validCells.add(new int[] {lowerRow, i});
            }
        }

        // get right row cells ^^
        for (int i = lowerRow - 1; i > upperRow; i--) {
            if (isCellValid(i, leftCol, matrix)) {
                validCells.add(new int[] {i, leftCol});
            }
        }

        return  validCells;
    }

    private static ArrayList<int[]> getValidCellsInRangeCounterClockwise
            (char[][] matrix, int centerRow, int centerCol, int radius) {
        ArrayList<int[]> validCells = new ArrayList<>();
        int upperRow = centerRow - radius;
        int lowerRow = centerRow + radius;
        int leftCol = centerCol - radius;
        int rightCol = centerCol + radius;
        // get upper row cells <<
        for (int i = rightCol; i >= leftCol ; i--) {
            if (isCellValid(upperRow, i, matrix)) {
                validCells.add(new int[] {upperRow, i});
            }
        }

        // get right row cells vv
        for (int i = upperRow + 1; i < lowerRow; i++) {
            if (isCellValid(i, leftCol, matrix)) {
                validCells.add(new int[] {i, leftCol});
            }
        }

        // get lower row cells >>
        for (int i = leftCol; i <= rightCol; i++) {
            if (isCellValid(lowerRow, i, matrix)) {
                validCells.add(new int[] {lowerRow, i});
            }
        }

        // get right col cells ^^
        for (int i = lowerRow - 1; i > upperRow; i--) { // -1?
            if (isCellValid(i, rightCol, matrix)) {
                validCells.add(new int[] {i, rightCol});
            }
        }

        return  validCells;
    }
}
