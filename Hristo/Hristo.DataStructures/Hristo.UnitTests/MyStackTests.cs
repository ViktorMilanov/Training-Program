using NUnit.Framework;

namespace Hristo.DataStructures.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_WhenValueIsPushed_ShouldIncrementCount()
        {
            // Arrange
            var stack = new MyStack<int>();

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void Pop_WhenStackIsNotEmpty_ShouldRemoveAndReturnTopValue()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            int poppedValue1 = stack.Pop();
            int poppedValue2 = stack.Pop();

            // Assert
            Assert.That(poppedValue1, Is.EqualTo(3));
            Assert.That(poppedValue2, Is.EqualTo(2));
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenStackIsEmpty_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var stack = new MyStack<int>();

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_WhenStackIsNotEmpty_ShouldReturnTopValueWithoutRemovingIt()
        {
            // Arrange
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            int peekedValue = stack.Peek();

            // Assert
            Assert.That(peekedValue, Is.EqualTo(3));
            Assert.That(stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void Peek_WhenStackIsEmpty_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var stack = new MyStack<int>();

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void IsEmpty_WhenStackIsEmpty_ShouldReturnTrue()
        {
            // Arrange
            var stack = new MyStack<int>();

            // Act
            bool isEmpty = stack.IsEmpty();

            // Assert
            Assert.That(isEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_WhenStackIsNotEmpty_ShouldReturnFalse()
        {
            // Arrange
            var stack = new MyStack<int>();
            stack.Push(1);

            // Act
            bool isEmpty = stack.IsEmpty();

            // Assert
            Assert.That(isEmpty, Is.False);
        }
    }


}
