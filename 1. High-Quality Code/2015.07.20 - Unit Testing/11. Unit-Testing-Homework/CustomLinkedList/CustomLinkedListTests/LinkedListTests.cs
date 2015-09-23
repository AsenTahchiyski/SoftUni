namespace CustomLinkedListTests
{
    using System;
    using System.Diagnostics;
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    // Arrange, Act, Assert

    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void TestConstructor_ObjectShouldNotBeNull()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Assert
            Debug.Assert(testList != null, "Constructor should not create a null object.");
        }

        [TestMethod]
        public void TestConstructor_NewListShouldBeEmpty()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Assert
            Debug.Assert(testList != null, "Constructor should not create a null object.");
            Debug.Assert(testList.Count == 0, "Constructor should not create an empty list.");
        }

        [TestMethod]
        public void TestCountProperty_CountShouldBe10After10ElementsAdded()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);

            // Assert
            Debug.Assert(testList.Count == 10, "After adding 10 elements the count should be 10.");
        }

        [TestMethod]
        public void TestIndexing_ElementAtIndex7ShouldBeEqualTo7()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);

            // Assert
            Debug.Assert(testList[7] == 7, "Element at index 7 should be = 7.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Trying to access element at wrong index should throw ArgumentOutOfRangeException.")]
        public void TestIndexing_AccessingWrongIndexShouldThrowAnException()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            int test = testList[11];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Trying to access element at wrong index should throw ArgumentOutOfRangeException.")]
        public void TestIndexing_AccessingNegativeIndexShouldThrowAnException()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            int test = testList[-1];
        }

        [TestMethod]
        public void TestIndexing_ElementAtIndex3ShouldBeEqualToIntMaxValue()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            testList[3] = int.MaxValue;

            // Assert
            Debug.Assert(testList[3] == int.MaxValue, "Element at index 3 should be = int.MaxValue.");
        }

        [TestMethod]
        public void TestIndexing_ElementAtIndex9ShouldBeEqualToIntMinValue()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            testList[8] = int.MinValue;

            // Assert
            Debug.Assert(testList[8] == int.MinValue, "Element at index 8 should be = int.MinValue.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Trying to set element at wrong index should throw ArgumentOutOfRangeException.")]
        public void TestIndexing_SettingWrongIndexShouldThrowAnException()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            testList[11] = 5;
        }

        [TestMethod]
        public void TestRemoveAt_ElementAtIndex8ShouldBe9()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            testList.RemoveAt(8);

            // Assert
            Debug.Assert(testList[8] == 9, "Element at index 8 should be = 9.");
        }

        [TestMethod]
        public void TestRemoveAt_CountShouldBe5LessAfter5ElementRemoval()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            testList.RemoveAt(2);
            testList.RemoveAt(2);
            testList.RemoveAt(2);
            testList.RemoveAt(2);
            testList.RemoveAt(2);

            // Assert
            Debug.Assert(testList.Count == 5, "Element count should be = 5.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Trying to remove element at wrong index should throw ArgumentOutOfRangeException.")]
        public void TestRemoveAt_TryingToRemoveElementAtWrongIndexShouldThrowAnException()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            testList.RemoveAt(10);
        }

        [TestMethod]
        public void TestRemove_ElementAtIndex5ShouldBe6()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            testList.Remove(5);

            // Assert
            Debug.Assert(testList[5] == 6, "Element at index 5 should be = 6.");
        }

        [TestMethod]
        public void TestRemove_CountShouldBe5LessAfter5ElementRemoval()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            testList.Remove(2);
            testList.Remove(3);
            testList.Remove(4);
            testList.Remove(5);
            testList.Remove(6);

            // Assert
            Debug.Assert(testList.Count == 5, "Element count should be = 5.");
        }

        [TestMethod]
        public void TestRemove_TryingToRemoveElementAtWrongIndex()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            int test = testList.Remove(10);

            // Assert
            Debug.Assert(testList.Count == 10 && test == -1, "Trying to remove unexisting element should return -1.");
        }

        [TestMethod]
        public void TestRemove_ReturnedIndexShouldBe5()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            int test = testList.Remove(5);

            // Assert
            Debug.Assert(testList.Count == 9 && test == 5, "Removing element at position 5 should return index = 5.");
        }

        [TestMethod]
        public void TestIndexOf_ReturnedIndexShouldBe9()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            int test = testList.IndexOf(9);

            // Assert
            Debug.Assert(testList.Count == 10 && test == 9, "Getting the index of the 9th element should return 9.");
        }

        [TestMethod]
        public void TestIndexOf_TryingToGetIndexOfMissingElementShouldReturnMinus1()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            int test = testList.IndexOf(10);

            // Assert
            Debug.Assert(test == -1, "Trying to get the index of non-existent element should return -1.");
        }

        [TestMethod]
        public void TestContains_ShouldReturnTrueForElementsInTheList()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            bool test = testList.Contains(5);

            // Assert
            Debug.Assert(test == true, "Checking for existing elements should return true.");
        }

        [TestMethod]
        public void TestContains_ShouldReturnFalseForElementsNotInTheList()
        {
            // Arrange
            DynamicList<int> testList = new DynamicList<int>();

            // Act
            FillTestListWith10Elements(testList);
            bool test = testList.Contains(51);

            // Assert
            Debug.Assert(test == false, "Checking for non existing elements should return false.");
        }

        private DynamicList<int> FillTestListWith10Elements(DynamicList<int> testList)
        {
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Add(5);
            testList.Add(6);
            testList.Add(7);
            testList.Add(8);
            testList.Add(9);

            return testList;
        } 
    }
}
