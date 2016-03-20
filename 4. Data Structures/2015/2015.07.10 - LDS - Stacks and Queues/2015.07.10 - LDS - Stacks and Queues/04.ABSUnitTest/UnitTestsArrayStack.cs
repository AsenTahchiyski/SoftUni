namespace ArrayBasedStack.Tests
{
    using ArrayBasedStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void TestPushPopElement()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(6);

            // I'll know how to make unit testing in a week.
        }
    }
}


