namespace BigListTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Wintellect.PowerCollections;

    [TestClass]
    public class BigListTest
    {
        [TestMethod]
        public void TestConstructor_ObjectShouldNotBeNull()
        {
            // Arrange
            BigList<int> list = new BigList<int>();

            // Act
            // Assert
            Assert.IsNotNull(list, "List is null, should be empty but non-null.");
        }

        [TestMethod]
        public void TestAddSingleElement_CountShouldBe1()
        {
            // Arrange
            BigList<int> list = new BigList<int>();

            // Act
            list.Add(5);

            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 1, "Elements count is not 1.");
        }

        [TestMethod]
        public void TestAddTenElements_CountShouldBe10()
        {
            // Arrange
            BigList<int> list = new BigList<int>();

            // Act
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);

            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 10, "Elements count is not 1.");
        }

        [TestMethod]
        public void TestRemoveElements_CountShouldDecrease()
        {
            // Arrange
            BigList<int> list = new BigList<int>();

            // Act
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            list.Add(5);
            
            list.Remove(5);

            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 9, "Elements count is not 9.");
        }

        [TestMethod]
        public void TestAddRange_ShouldAddArrayOf10Elements()
        {
            // Arrange
            BigList<int> list = new BigList<int>();
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            
            // Act
            list.AddRange(array);
            
            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 10, "Elements count is not 10.");
        }

        [TestMethod]
        public void TestClear_ElementsShouldBe0()
        {
            // Arrange
            BigList<int> list = new BigList<int>();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            // Act
            list.Clear();
            
            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 0, "Elements count is not 0.");
        }

        [TestMethod]
        public void TestIndexing_ElementsShouldBe0()
        {
            // Arrange
            BigList<int> list = new BigList<int>();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            // Act
            list.AddRange(array);
            int a = list[4];
            
            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(a == 5, "Element at index 4 is not == 5.");
        }

        [TestMethod]
        public void TestRemoveAt_Element8ShouldBe0()
        {
            // Arrange
            BigList<int> list = new BigList<int>();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            // Act
            list.AddRange(array);
            list.RemoveAt(8);
            int a = list[8];
            
            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(a == 0, "Element at index 8 is not == 0.");
        }

        [TestMethod]
        public void TestReverse_Element0ShouldBe0()
        {
            // Arrange
            BigList<int> list = new BigList<int>();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            // Act
            list.AddRange(array);
            list.Reverse();
            int a = list[0];
            
            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(a == 0, "Element at index 0 is not == 0.");
        }

        [TestMethod]
        public void TestSort_Element0ShouldBe0()
        {
            // Arrange
            BigList<int> list = new BigList<int>();
            int[] array = { 4, 2, 7, 3, 0, 1, 5, 9, 8 };

            // Act
            list.AddRange(array);
            list.Sort();
            int a = list[0];
            
            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(a == 0, "Element at index 0 is not == 0.");
        }

        [TestMethod]
        public void TestReverse_Element0ShouldBe8()
        {
            // Arrange
            BigList<int> list = new BigList<int>();
            int[] array = { 4, 2, 7, 3, 0, 1, 5, 9, 8 };

            // Act
            list.AddRange(array);
            list.Reverse();
            int a = list[0];
            
            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(a == 8, "Element at index 0 is not == 8.");
        }

        [TestMethod] public void TestConvertAll_ElementsShouldBeStrings()
        {
            // Arrange
            BigList<int> list = new BigList<int>();
            int[] array = { 4, 2, 7, 3, 0, 1, 5, 9, 8 };
            BigList<string> listString = new BigList<string>();

            // Act
            list.AddRange(array);
            listString = list.ConvertAll(x => x.ToString());
            string a = listString[0];
            
            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(a == "4", "Element at index 0 is not a string.");
        }
    }
}
