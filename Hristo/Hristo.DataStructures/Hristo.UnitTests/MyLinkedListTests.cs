using NUnit.Framework;

namespace Hristo.DataStructures.UnitTests
{
[TestFixture]
    public class MyLinkedListTests
    {
        [Test]
        public void Add_WhenValueIsAdded_ShouldIncrementCount()
        {
            // Arrange
            var linkedList = new MyLinkedList<int>();

            // Act
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            // Assert
            Assert.That(linkedList.Count, Is.EqualTo(3));
        }

        [Test]
        public void Contains_WhenValueExistsInList_ShouldReturnTrue()
        {
            // Arrange
            var linkedList = new MyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            // Act
            bool containsValue = linkedList.Contains(2);

            // Assert
            Assert.IsTrue(containsValue);
        }

        [Test]
        public void Contains_WhenValueDoesNotExistInList_ShouldReturnFalse()
        {
            // Arrange
            var linkedList = new MyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            // Act
            bool containsValue = linkedList.Contains(4);

            // Assert
            Assert.IsFalse(containsValue);
        }

        [Test]
        public void Find_WhenValueExistsInList_ShouldReturnNodeWithMatchingValue()
        {
            // Arrange
            var linkedList = new MyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            // Act
            var node = linkedList.Find(2);

            // Assert
            Assert.That(node, Is.Not.Null);
            Assert.That(node.Value, Is.EqualTo(2));
        }

        [Test]
        public void Find_WhenValueDoesNotExistInList_ShouldReturnNull()
        {
            // Arrange
            var linkedList = new MyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            // Act
            var node = linkedList.Find(4);

            // Assert
            Assert.That(node, Is.Null);
        }
    }

}