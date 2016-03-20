using System;
using p7.LinkedQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p8.LinkedQueueTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEnqueueDequeue_OneElement_ShouldReturnCorrectValue()
        {
            var stack = new LinkedQueue<int>();
            Assert.IsTrue(stack.Count == 0);
            stack.Enqueue(420);
            Assert.IsTrue(stack.Count == 1);
            var elementReturned = stack.Dequeue();
            Assert.AreEqual(420, elementReturned);
            Assert.IsTrue(stack.Count == 0);
        }

        [TestMethod]
        public void TestEnqueueDequeue_1000Elements_ShouldReturnCorrectValue()
        {
            var stack = new LinkedQueue<string>();
            Assert.IsTrue(stack.Count == 0);

            for (int i = 0; i < 1000; i++)
            {
                stack.Enqueue(i.ToString());
                Assert.IsTrue(stack.Count == i + 1);
            }

            for (int i = 0; i < 1000; i++)
            {
                var element = stack.Dequeue();
                Assert.AreEqual(i.ToString(), element);
                Assert.IsTrue(stack.Count == 1000 - i - 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Queue is empty.")]
        public void TestDequeueOnEmptyStack_ShouldThrowAnException()
        {
            var stack = new LinkedQueue<int>();
            stack.Dequeue();
        }

        [TestMethod]
        public void TestEnqueueDequeue_ShouldReturnCorrectResultsAndUpdateCounterProperly()
        {
            var stack = new LinkedQueue<string>();
            Assert.IsTrue(stack.Count == 0);
            stack.Enqueue("wow");
            Assert.IsTrue(stack.Count == 1);
            stack.Enqueue("yeah");
            Assert.IsTrue(stack.Count == 2);
            var element = stack.Dequeue();
            Assert.AreEqual("wow", element);
            Assert.IsTrue(stack.Count == 1);
            element = stack.Dequeue();
            Assert.AreEqual("yeah", element);
            Assert.IsTrue(stack.Count == 0);
        }

        [TestMethod]
        public void TestToArray_ShouldReturnCorrectResult()
        {
            var stack = new LinkedQueue<int>();
            stack.Enqueue(3);
            stack.Enqueue(5);
            stack.Enqueue(-2);
            stack.Enqueue(7);
            var toArray = stack.ToArray();
            var expected = new int[] { 3, 5, -2, 7 };
            CollectionAssert.AreEqual(expected, toArray);
        }

        [TestMethod]
        public void TestEmptyStackToArray_ShouldReturnEmptyArray()
        {
            var stack = new LinkedQueue<DateTime>();
            var array = stack.ToArray();
            var expected = new DateTime[0];
            CollectionAssert.AreEqual(expected, array);
        }
    }
}
