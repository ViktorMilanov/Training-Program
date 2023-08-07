using NUnit.Framework;
using System;

namespace VM.DataStructures.UnitTests
{
    public class CustomQueueTests
    {
        private CustomQueue<int> _queue = null!;
        [SetUp]
        public void Setup()
        {
            _queue = new CustomQueue<int>();
        }

        [Test]
        public void Enqueue_TheFirstAddedElementInQueueShouldBeEqualWithFrontAndRearElement()
        {
            int number = 1;

            _queue.Enqueue(number);

            Assert.AreEqual(1, _queue.Count);
            Assert.IsTrue(_queue.Contains(number));
        }
        [Test]
        public void Enqueue_AddedElementInQueueShouldBeAddedAtTheEnd()
        {
            int number1 = 1;
            int number2 = 2;

            _queue.Enqueue(number1);
            _queue.Enqueue(number2);

            Assert.AreEqual(2, _queue.Count);
            Assert.IsTrue(_queue.Contains(number1));
            Assert.IsTrue(_queue.Contains(number2));
            Assert.AreEqual(number1, _queue.Peek());
        }
        [Test]
        public void Dequeue_ShouldThrowErrorIfTheQueueIsEmpty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                _queue.Dequeue();
            });
            StringAssert.Contains("Queue is Empty", ex.Message.ToString());
        }
        [Test]
        public void Dequeue_ShouldRemoveTheFirstAddedElement()
        {
            int number1 = 1;
            int number2 = 2;

            _queue.Enqueue(number1);
            _queue.Enqueue(number2);

            Assert.AreEqual(number1, _queue.Dequeue());
            Assert.AreEqual(1, _queue.Count);
            Assert.IsFalse(_queue.Contains(number1));
            Assert.IsTrue(_queue.Contains(number2));
        }
        [Test]
        public void Dequeue_WhenTheLastRemainingElementIsRemovedTheQueueShouldBeEmpty()
        {
            int number1 = 1;

            _queue.Enqueue(number1);

            Assert.AreEqual(number1, _queue.Dequeue());
            Assert.IsTrue(_queue.IsEmpty());
        }
        [Test]
        public void Peek_ShouldThrowErrorIfTheQueueIsEmpty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                _queue.Peek();
            });
            StringAssert.Contains("Queue is Empty", ex.Message.ToString());
        }
        [Test]
        public void Peek_ShouldReturnTheFirstAddedElement()
        {
            int number1 = 1;
            int number2 = 2;

            _queue.Enqueue(number1);
            _queue.Enqueue(number2);

            Assert.AreEqual(number1, _queue.Peek());
        }
        [Test]
        public void Clear_ShouldRemoveAllElements()
        {
            int number1 = 1;
            int number2 = 2;

            _queue.Enqueue(number1);
            _queue.Enqueue(number2);
            _queue.Clear();

            Assert.IsTrue(_queue.IsEmpty());
        }
        [Test]
        public void IsEmpty_ShouldReturnTrueIfThereIsntElementsInTheQueue()
        {
            Assert.IsTrue(_queue.IsEmpty());
        }
        [Test]
        public void IsEmpty_ShouldReturnFalseIfThereIsElementsInTheQueue()
        {
            int number1 = 1;
            int number2 = 2;

            _queue.Enqueue(number1);
            _queue.Enqueue(number2);

            Assert.IsFalse(_queue.IsEmpty());
        }
        [Test]
        public void Contains_ShouldReturnFalseIfTheQueueIsEmpty()
        {
            Assert.IsFalse(_queue.Contains(1));
        }
        [Test]
        public void Contains_ShouldReturnTrueIfSearchedElementIsFirstElementInTheQueue()
        {
            int number1 = 1;
            int number2 = 2;

            _queue.Enqueue(number1);
            _queue.Enqueue(number2);

            Assert.IsTrue(_queue.Contains(1));
        }
        [Test]
        public void Contains_ShouldReturnTrueIfSearchedElementIsAnyElementInTheQueue()
        {
            int number1 = 1;
            int number2 = 2;

            _queue.Enqueue(number1);
            _queue.Enqueue(number2);

            Assert.IsTrue(_queue.Contains(2));
        }
        [Test]
        public void Contains_ShouldReturnFalseIfSearchedElementIsntInTheQueue()
        {
            int number1 = 1;
            int number2 = 2;

            _queue.Enqueue(number1);
            _queue.Enqueue(number2);

            Assert.IsFalse(_queue.Contains(3));
        }
    }
}