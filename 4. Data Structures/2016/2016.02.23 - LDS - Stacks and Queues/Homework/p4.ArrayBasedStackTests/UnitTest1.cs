using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p3.ArrayBasedStack;

namespace p4.ArrayBasedStackTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPushPop_OneElement_ShouldReturnCorrectValue()
        {
            var stack = new ArrayStack<int>();
            Assert.IsTrue(stack.Count == 0);
            stack.Push(420);
            Assert.IsTrue(stack.Count == 1);
            var elementReturned = stack.Pop();
            Assert.AreEqual(420, elementReturned);
            Assert.IsTrue(stack.Count == 0);
        }

        [TestMethod]
        public void TestPushPop_1000Elements_ShouldReturnCorrectValue()
        {
            var stack = new ArrayStack<string>();
            Assert.IsTrue(stack.Count == 0);

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i.ToString());
                Assert.IsTrue(stack.Count == i + 1);
            }

            for (int i = 999; i >= 0; i--)
            {
                var element = stack.Pop();
                Assert.AreEqual(i.ToString(), element);
                Assert.IsTrue(stack.Count == i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Stack is empty.")]
        public void TestPopOnEmptyStack_ShouldThrowAnException()
        {
            var stack = new ArrayStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void TestPushPop_Capacity1_ShouldReturnCorrectResultsAndUpdateCounterProperly()
        {
            var stack = new ArrayStack<string>(1);
            Assert.IsTrue(stack.Count == 0);
            stack.Push("wow");
            Assert.IsTrue(stack.Count == 1);
            stack.Push("yeah");
            Assert.IsTrue(stack.Count == 2);
            var element = stack.Pop();
            Assert.AreEqual("yeah", element);
            Assert.IsTrue(stack.Count == 1);
            element = stack.Pop();
            Assert.AreEqual("wow", element);
            Assert.IsTrue(stack.Count == 0);
        }

        [TestMethod]
        public void TestToArray_ShouldReturnCorrectResult()
        {
            var stack = new ArrayStack<int>();
            stack.Push(3);
            stack.Push(5);
            stack.Push(-2);
            stack.Push(7);
            var toArray = stack.ToArray();
            var expected = new int[] { 7, -2, 5, 3 };
            CollectionAssert.AreEqual(expected, toArray);
        }

        [TestMethod]
        public void TestEmptyStackToArray_ShouldReturnEmptyArray()
        {
            var stack = new ArrayStack<DateTime>();
            var array = stack.ToArray();
            var expected = new DateTime[0];
            CollectionAssert.AreEqual(expected, array);
        }
    }
}