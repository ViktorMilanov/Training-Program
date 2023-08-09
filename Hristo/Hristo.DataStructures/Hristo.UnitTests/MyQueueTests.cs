using NUnit.Framework;

namespace Hristo.DataStructures.UnitTests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Enqueue_WhenValueIsEnqueued_ShouldIncrementCount()
        {
            // Arrange
            var queue = new MyQueue<int>();

            // Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Assert
            Assert.That(queue.Count, Is.EqualTo(3));
        }

        [Test]
        public void Dequeue_WhenQueueIsNotEmpty_ShouldRemoveAndReturnHeadValue()
        {
            // Arrange
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Act
            int dequeuedValue1 = queue.Dequeue();
            int dequeuedValue2 = queue.Dequeue();

            // Assert
            Assert.That(dequeuedValue1, Is.EqualTo(1));
            Assert.That(dequeuedValue2, Is.EqualTo(2));
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void Dequeue_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var queue = new MyQueue<int>();

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_WhenQueueIsNotEmpty_ShouldReturnHeadValueWithoutRemovingIt()
        {
            // Arrange
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Act
            int peekedValue = queue.Peek();

            // Assert
            Assert.AreEqual(1, peekedValue);
            Assert.AreEqual(3, queue.Count);
        }

        [Test]
        public void Peek_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var queue = new MyQueue<int>();

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void IsEmpty_WhenQueueIsEmpty_ShouldReturnTrue()
        {
            // Arrange
            var queue = new MyQueue<int>();

            // Act
            bool isEmpty = queue.IsEmpty();

            // Assert
            Assert.That(isEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_WhenQueueIsNotEmpty_ShouldReturnFalse()
        {
            // Arrange
            var queue = new MyQueue<int>();
            queue.Enqueue(1);

            // Act
            bool isEmpty = queue.IsEmpty();

            // Assert
            Assert.That(isEmpty, Is.False);
        }
    }

}
