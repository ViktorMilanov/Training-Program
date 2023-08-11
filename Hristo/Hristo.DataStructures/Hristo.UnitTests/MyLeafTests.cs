using NUnit.Framework;

namespace Hristo.DataStructures.UnitTests
{
    [TestFixture]
    public class TreeNodeTests
    {
        [Test]
        public void Add_WhenLeafIsAdded_ShouldSetParentAndAddToChildrenList()
        {
            // Arrange
            var root = new MyTreeNode<int>(1);
            var leaf = new MyTreeNode<int>(2);

            // Act
            root.Add(leaf);

            // Assert
            Assert.That(leaf.Parent, Is.EqualTo(root));
            Assert.That((System.Collections.ICollection?)root.Children, Does.Contain(leaf));
        }

        [Test]
        public void Remove_WhenLeafExistsInChildren_ShouldRemoveFromChildrenListAndClearParent()
        {
            // Arrange
            var root = new MyTreeNode<int>(1);
            var leaf = new MyTreeNode<int>(2);
            root.Add(leaf);

            // Act
            root.Remove(leaf);

            // Assert
            Assert.That(leaf.Parent, Is.Null);
            Assert.That(root.Children, Is.Empty);
        }

        [Test]
        public void Contains_WhenLeafWithMatchingValueExistsInTree_ShouldReturnTrue()
        {
            // Arrange
            var root = new MyTreeNode<int>(1);
            var leaf1 = new MyTreeNode<int>(2);
            var leaf2 = new MyTreeNode<int>(3);
            root.Add(leaf1);
            leaf1.Add(leaf2);

            // Act
            bool containsValue = root.Contains(3);

            // Assert
            Assert.That(containsValue, Is.True);
        }

        [Test]
        public void Contains_WhenLeafWithMatchingValueDoesNotExistInTree_ShouldReturnFalse()
        {
            // Arrange
            var root = new MyTreeNode<int>(1);
            var leaf1 = new MyTreeNode<int>(2);
            var leaf2 = new MyTreeNode<int>(3);
            root.Add(leaf1);
            leaf1.Add(leaf2);

            // Act
            bool containsValue = root.Contains(4);

            // Assert
            Assert.That(containsValue, Is.False);
        }

        [Test]
        public void Find_WhenLeafWithMatchingValueExistsInTree_ShouldReturnMatchingLeafNode()
        {
            // Arrange
            var root = new MyTreeNode<int>(1);
            var leaf1 = new MyTreeNode<int>(2);
            var leaf2 = new MyTreeNode<int>(3);
            root.Add(leaf1);
            leaf1.Add(leaf2);

            // Act
            var foundNode = root.Find(3);

            // Assert
            Assert.That(foundNode, Is.EqualTo(leaf2));
        }

        [Test]
        public void Find_WhenLeafWithMatchingValueDoesNotExistInTree_ShouldReturnNull()
        {
            // Arrange
            var root = new MyTreeNode<int>(1);
            var leaf1 = new MyTreeNode<int>(2);
            var leaf2 = new MyTreeNode<int>(3);
            root.Add(leaf1);
            leaf1.Add(leaf2);

            // Act
            var foundNode = root.Find(4);

            // Assert
            Assert.That(foundNode, Is.Null);
        }
    }
}
