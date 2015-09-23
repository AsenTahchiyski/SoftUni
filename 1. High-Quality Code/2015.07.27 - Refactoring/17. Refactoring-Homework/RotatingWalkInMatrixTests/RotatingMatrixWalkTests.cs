namespace RotatingWalkInMatrixTests
{
    using System;
    using System.IO;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RotatingWalkMatrix;

    [TestClass]
    public class RotatingMatrixWalkTests
    {
        public int[,] matrix =
        {
            {1, 2, 3, 4, 5},
            {6, 7, 8, 9, 10},
            {11, 12, 13, 14, 15},
            {16, 17, 18, 19, 20},
            {21, 22, 23, 24, 25}
        };

        [TestMethod]
        public void TestPrintMatrix_CorrectOutputFormatting()
        {
            // Arrange
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);

                // Act
                RotatingWalkInMatrix.PrintMatrix(matrix);
                string actualOutput = writer.ToString();
                string expectedOutput = string.Format("  1  2  3  4  5{0}  6  7  8  9 10{0} 11 12 13 14 15{0} 16 17 18 19 20{0} 21 22 23 24 25{0}",
                    Environment.NewLine);

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput, "Expected and actual output do not match.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TestPrintMatrix_NullMatrix()
        {
            // Act
            RotatingWalkInMatrix.PrintMatrix(null);
        }

        [TestMethod]
        public void TestIsMoveAllowed_ValidMove()
        {
            // Arrange
            bool moveAllowed = false;
            matrix[2, 2] = 0;
            
            // Act
            moveAllowed = RotatingWalkInMatrix.IsMoveAllowed(matrix, 1, 1);

            // Assert
            Assert.IsTrue(moveAllowed, "Move should be allowed since the position is valid.");
        }

        [TestMethod]
        public void TestIsMoveAllowed_InvalidMove_AlreadyWalked()
        {
            // Arrange
            bool moveAllowed = true;

            // Act
            moveAllowed = RotatingWalkInMatrix.IsMoveAllowed(matrix, 1, 1);

            // Assert
            Assert.IsFalse(moveAllowed, "Move should be allowed since the position is valid.");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIsMoveAllowed_InvalidMove_InvalidPosition()
        {
            // Act
            RotatingWalkInMatrix.IsMoveAllowed(matrix, 5, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsMoveAllowed_InvalidMove_NullMatrix()
        {
            // Act
            RotatingWalkInMatrix.IsMoveAllowed(null, 1, 1);
        }

        [TestMethod]
        public void TestIsMoveAllowed_ValidMoveBorderCase()
        {
            // Arrange
            bool moveAllowed = false;
            matrix[4, 3] = 0;

            // Act
            moveAllowed = RotatingWalkInMatrix.IsMoveAllowed(matrix, 4, 4);

            // Assert
            Assert.IsTrue(moveAllowed, "Move should be allowed since the position is valid.");
        }

        [TestMethod]
        public void TestFindEmptyCell_ValidEmptyCell()
        {
            // Arrange
            matrix[4, 3] = 0;
            var emptyCell = new RotatingWalkInMatrix.Position(4, 3);

            // Act
            var positionFound = RotatingWalkInMatrix.FindEmptyCell(matrix);

            // Assert
            Assert.AreEqual(emptyCell.X, positionFound.X);
            Assert.AreEqual(emptyCell.Y, positionFound.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindEmptyCell_NullMatrix()
        {
            // Act
            RotatingWalkInMatrix.FindEmptyCell(null);
        }

        [TestMethod]
        public void TestFindEmptyCell_NoEmptyCell()
        {
            // Act
            var positionFound = RotatingWalkInMatrix.FindEmptyCell(matrix);

            // Assert
            Assert.AreEqual(null, positionFound);
        }

        [TestMethod]
        public void TestChangeWalkDirection_FirstCellEmptyPerimeter()
        {
            // Arrange
            matrix[0, 1] = matrix[1, 1] = matrix[1, 0] = 0;

            // Act
            RotatingWalkInMatrix.Position directionChange = RotatingWalkInMatrix.ChangeWalkDirection(0, 0);

            // Assert
            Assert.AreEqual(1, directionChange.X);
            Assert.AreEqual(0, directionChange.Y);
        }

        [TestMethod]
        public void TestChangeWalkDirection_LastCellEmptyLeftCell()
        {
            // Act
            RotatingWalkInMatrix.Position directionChange = RotatingWalkInMatrix.ChangeWalkDirection(4, 4);

            // Assert
            Assert.AreEqual(1, directionChange.X);
            Assert.AreEqual(0, directionChange.Y);
        }

        [TestMethod]
        public void TestIsNextPositionInvalid_InvalidPositionValue()
        {
            // Arrange
            RotatingWalkInMatrix.Position currentPosition = new RotatingWalkInMatrix.Position(1, 1);
            RotatingWalkInMatrix.Position movementDirection = new RotatingWalkInMatrix.Position(1, 1);

            // Act
            bool isNextPositionInvalid = RotatingWalkInMatrix.IsNextPositionInvalid(currentPosition.X, currentPosition.Y,
                movementDirection.X, movementDirection.Y, matrix);

            // Assert
            Assert.IsTrue(isNextPositionInvalid);
        }

        [TestMethod]
        public void TestIsNextPositionInvalid_ValidPosition()
        {
            // Arrange
            RotatingWalkInMatrix.Position currentPosition = new RotatingWalkInMatrix.Position(1, 2);
            matrix[2, 3] = 0;
            RotatingWalkInMatrix.Position movementDirection = new RotatingWalkInMatrix.Position(1, 1);

            // Act
            bool isNextPositionInvalid = RotatingWalkInMatrix.IsNextPositionInvalid(currentPosition.X, currentPosition.Y,
                movementDirection.X, movementDirection.Y, matrix);

            // Assert
            Assert.IsFalse(isNextPositionInvalid);
        }

        [TestMethod]
        public void TestIsNextPositionValid_InvalidPositionCoordinates()
        {
            // Arrange
            RotatingWalkInMatrix.Position currentPosition = new RotatingWalkInMatrix.Position(5, 5);
            RotatingWalkInMatrix.Position movementDirection = new RotatingWalkInMatrix.Position(1, 1);

            // Act
            bool isNextPositionInvalid = RotatingWalkInMatrix.IsNextPositionInvalid(
                currentPosition.X, currentPosition.Y,
                movementDirection.X, movementDirection.Y, matrix);

            // Assert
            Assert.IsTrue(isNextPositionInvalid);
        }

        [TestMethod]
        public void TestIsNextPositionValid_InvalidMoveCoordinates()
        {
            // Arrange
            RotatingWalkInMatrix.Position currentPosition = new RotatingWalkInMatrix.Position(4, 4);
            RotatingWalkInMatrix.Position movementDirection = new RotatingWalkInMatrix.Position(1, 1);

            // Act
            bool isNextPositionInvalid = RotatingWalkInMatrix.IsNextPositionInvalid(
                currentPosition.X, currentPosition.Y,
                movementDirection.X, movementDirection.Y, matrix);

            // Assert
            Assert.IsTrue(isNextPositionInvalid);
        }

        [TestMethod]
        public void TestPerformMatrixWalk_ReturnValueCheckSize5()
        {
            // Arrange
            int[,] emptyMatrix = new int[5, 5];
            int actualOutput = RotatingWalkInMatrix.PerformMatrixWalk(emptyMatrix, 0, 0, 1, 1, 1);
            int expectedOutput = 22;

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "Expected and actual output do not match.");
        }

        [TestMethod]
        public void TestPerformMatrixWalk_ReturnValueCheckSize()
        {
            // Arrange
            int[,] emptyMatrix = new int[1, 1];
            int actualOutput = RotatingWalkInMatrix.PerformMatrixWalk(emptyMatrix, 0, 0, 1, 1, 1);
            int expectedOutput = 1;

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "Expected and actual output do not match.");
        }

        [TestMethod]
        public void TestMain_ProblemExample()
        {
            // Arrange
            using (StringWriter writer = new StringWriter())
            {
                using (StringReader reader = new StringReader("5"))
                {
                    Console.SetOut(writer);
                    Console.SetIn(reader);

                    // Act
                    RotatingWalkInMatrix.Main();
                    string actualOutput = writer.ToString();
                    string expectedOutputPart0 = "Enter a number between 0 and 100: ";
                    
                    string expectedOutputPart1 = 
                        string.Format(
                        "  1 13 14 15 16{0} 12  2 21 22 17{0} 11  0  3 20 18{0} 10  0  0  4 19{0}  9  8  7  6  5{0}",
                        Environment.NewLine);

                    string expectedOutputPart2 = new string('-', 20);

                    string expectedOutputPart3 =
                        string.Format(
                        "  1 13 14 15 16{0} 12  2 21 22 17{0} 11 22  3 20 18{0} 10 24 23  4 19{0}  9  8  7  6  5{0}",
                        Environment.NewLine);
                    
                        string expectedOutput = string.Format("{4}{0}{2}{1}{3}",
                        expectedOutputPart1, Environment.NewLine, expectedOutputPart2, expectedOutputPart3, expectedOutputPart0);

                    // Assert
                    Assert.AreEqual(expectedOutput, actualOutput, "Expected and actual output do not match.");    
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMain_IncorrectInput()
        {
            // Arrange
            using (StringReader reader = new StringReader("0"))
            {
                Console.SetIn(reader);

                // Act
                RotatingWalkInMatrix.Main();
            }
        }
    }
}
