using NUnit.Framework;
using System;

namespace VM.DataStructures.UnitTests
{
    public class CustomLinkedListTests
    {
        private CustomLinkedList<int> _linkedList = null!;
        [SetUp]
        public void Setup()
        {
            _linkedList = new CustomLinkedList<int>();
        }
        [Test]
        public void AddBefore_AddedElementInTheListShouldBeAddedBeforeTheElementThatIsPassed()
        {
            Node<int> newNode = new Node<int>();
            newNode.value = 2;
            int number1 = 1;
            int number2 = 3;
            int number3 = 4;
            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);
            var node = _linkedList.Find(3);
            _linkedList.AddBefore(node, newNode);

            Assert.AreEqual(4, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(newNode.value));
        }
        [Test]
        public void AddBefore_AddedElementInTheListShouldBeAddedBeforeTheElementThatIsPassedEvenIfTheElementIsFirst()
        {
            Node<int> newNode = new Node<int>();
            newNode.value = 1;
            int number1 = 2;
            int number2 = 3;
            int number3 = 4;
            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);
            var node = _linkedList.Find(2);
            _linkedList.AddBefore(node, newNode);

            Assert.AreEqual(4, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(newNode.value));
        }
        [Test]
        public void AddBefore_ShouldThrowErrorWhenPassedNodeToBeAdded()
        {
            int number1 = 1;
            int number2 = 2;
            int number3 = 4;
            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);
            var node = _linkedList.Find(2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                _linkedList.AddAfter(node, node);
            });
        }
        [Test]
        public void AddAfter_AddedElementInTheListShouldBeAddedAfterTheElementThatIsPassed()
        {
            Node<int> newNode = new Node<int>();
            newNode.value = 3;
            int number1 = 1;
            int number2 = 2;
            int number3 = 4;
            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);
            var node = _linkedList.Find(2);
            _linkedList.AddAfter(node, newNode);

            Assert.AreEqual(4, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(newNode.value));
        }
        [Test]
        public void AddAfter_AddedElementInTheListShouldBeAddedAfterTheElementThatIsPassedEvenIfItsLastElement()
        {
            Node<int> newNode = new Node<int>();
            newNode.value = 4;
            int number1 = 1;
            int number2 = 2;
            int number3 = 3;
            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);
            var node = _linkedList.Find(3);
            _linkedList.AddAfter(node, newNode);

            Assert.AreEqual(4, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(newNode.value));
        }
        [Test]
        public void AddAfter_ShouldThrowErrorWhenPassedNodeToBeAdded()
        {
            int number1 = 1;
            int number2 = 2;
            int number3 = 4;
            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);
            var node = _linkedList.Find(2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                _linkedList.AddAfter(node, node);
            });
        }
        [Test]
        public void AddFirst_TheFirstAddedElementInTheListShouldBeEqualWithFrontAndRearElement()
        {
            int number = 1;

            _linkedList.AddFirst(number);

            Assert.AreEqual(1, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(number));
        }
        [Test]
        public void AddFirst_AddedElementInTheStackShouldBeAddedAtTheStart()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddFirst(number1);
            _linkedList.AddFirst(number2);

            Assert.AreEqual(2, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(number1));
            Assert.IsTrue(_linkedList.Contains(number2));
        }

        [Test]
        public void AddLast_TheFirstAddedElementInTheListShouldBeEqualWithFrontAndRearElement()
        {
            int number = 1;

            _linkedList.AddLast(number);

            Assert.AreEqual(1, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(number));
        }
        [Test]
        public void AddLast_AddedElementInTheStackShouldBeAddedAtTheEnd()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            Assert.AreEqual(2, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(number1));
            Assert.IsTrue(_linkedList.Contains(number2));
        }
        /*[Test]
        public void AddAfter_AddedElementInTheStackShouldBeAddedAtTheStart()
        {
            Node<int> newNode = new Node<int>();
            Node<int> node1 = new Node<int>();
            node1.value = 1;
            Node<int> node3 = new Node<int>();
            node3.value = 4;
            Node<int> node = new Node<int>();
            node1.next = node;
            node.next = node3;
            node.prev = node1;
            node3.prev = node;
            node.value = 2;
            newNode.value = 3;
            int number1 = 1;
            int number2 = 2;
            int number3 = 4;
            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);

            _linkedList.AddBefore(node,newNode);

            Assert.AreEqual(2, _linkedList.Count);
            Assert.IsTrue(_linkedList.Contains(number1));
            Assert.IsTrue(_linkedList.Contains(number2));
        }*/
        [Test]
        public void Clear_ShouldRemoveAllElements()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.Clear();

            Assert.AreEqual(0, _linkedList.Count);
        }
        [Test]
        public void IsEmpty_ShouldReturnTrueIfThereIsntElementsInTheList()
        {
            Assert.IsTrue(_linkedList.IsEmpty());
        }
        [Test]
        public void IsEmpty_ShouldReturnFalseIfThereIsElementsInTheList()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            Assert.IsFalse(_linkedList.IsEmpty());
        }
        [Test]
        public void Contains_ShouldReturnFalseIfTheListIsEmpty()
        {
            Assert.IsFalse(_linkedList.Contains(1));
        }
        [Test]
        public void Contains_ShouldReturnTrueIfSearchedElementIsFirstElementInTheList()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            Assert.IsTrue(_linkedList.Contains(1));
        }
        [Test]
        public void Contains_ShouldReturnTrueIfSearchedElementIsAnyElementInTheList()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            Assert.IsTrue(_linkedList.Contains(2));
        }
        [Test]
        public void Contains_ShouldReturnFalseIfSearchedElementIsntInTheList()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            Assert.IsFalse(_linkedList.Contains(3));
        }
        [Test]
        public void Find_ShouldReturnNullIfTheListIsEmpty()
        {
            Assert.IsNull(_linkedList.Find(1));
        }
        [Test]
        public void Find_ShouldReturnNullIfSearchedElementIsntInTheList()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            Assert.IsNull(_linkedList.Find(3));
        }
        [Test]
        public void FindLast_ShouldReturnNullIfTheListIsEmpty()
        {
            Assert.IsNull(_linkedList.FindLast(1));
        }
        [Test]
        public void FindLast_ShouldReturnNullIfSearchedElementIsntInTheList()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            Assert.IsNull(_linkedList.FindLast(3));
        }
        [Test]
        public void Remove_ShouldThrowErrorIfTheListIsEmpty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                _linkedList.Remove(1);
            });
            StringAssert.Contains("Linked List is Empty", ex.Message.ToString());
        }
        [Test]
        public void Remove_ShouldRemoveTheFirstElementWhichValueIsTheSameAsThePassedOne()
        {
            int number1 = 1;
            int number2 = 2;
            int number3 = 3;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);

            _linkedList.Remove(3);

            Assert.AreEqual(2, _linkedList.Count);
            Assert.IsFalse(_linkedList.Contains(number3));
            Assert.IsTrue(_linkedList.Contains(number1));
        }
        [Test]
        public void Remove_WhenTheLastRemainingElementIsRemovedTheQueueShouldBeEmpty()
        {
            int number1 = 1;

            _linkedList.AddLast(number1);

            _linkedList.Remove(1);

            Assert.IsTrue(_linkedList.IsEmpty());
        }
        [Test]
        public void Remove_RemovesFirstElementIfItsValueIsTheSameAsThePassedOne()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            _linkedList.Remove(1);

            Assert.AreEqual(1, _linkedList.Count);
            Assert.IsFalse(_linkedList.Contains(number1));
            Assert.IsTrue(_linkedList.Contains(number2));
        }
        [Test]
        public void Remove_RemovesLastElementIfItsValueIsTheSameAsThePassedOne()
        {
            int number1 = 1;
            int number2 = 2;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);

            _linkedList.Remove(2);

            Assert.AreEqual(1, _linkedList.Count);
            Assert.IsFalse(_linkedList.Contains(number2));
            Assert.IsTrue(_linkedList.Contains(number1));
        }
        [Test]
        public void RemoveFirst_ShouldThrowErrorIfTheListIsEmpty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                _linkedList.RemoveFirst();
            });
            StringAssert.Contains("Linked List is Empty", ex.Message.ToString());
        }
        [Test]
        public void RemoveFirst_ShouldRemoveTheFirstElementInTheList()
        {
            int number1 = 1;
            int number2 = 2;
            int number3 = 3;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);

            _linkedList.RemoveFirst();

            Assert.AreEqual(2, _linkedList.Count);
            Assert.IsFalse(_linkedList.Contains(number1));
            Assert.IsTrue(_linkedList.Contains(number2));
        }
        [Test]
        public void RemoveFirst_WhenTheLastRemainingElementIsRemovedTheQueueShouldBeEmpty()
        {
            int number1 = 1;

            _linkedList.AddLast(number1);

            _linkedList.RemoveFirst();

            Assert.IsTrue(_linkedList.IsEmpty());
        }
        public void RemoveLast_ShouldThrowErrorIfTheListIsEmpty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                _linkedList.RemoveLast();
            });
            StringAssert.Contains("Linked List is Empty", ex.Message.ToString());
        }
        [Test]
        public void RemoveLast_ShouldRemoveTheFirstElementInTheList()
        {
            int number1 = 1;
            int number2 = 2;
            int number3 = 3;

            _linkedList.AddLast(number1);
            _linkedList.AddLast(number2);
            _linkedList.AddLast(number3);

            _linkedList.RemoveLast();

            Assert.AreEqual(2, _linkedList.Count);
            Assert.IsFalse(_linkedList.Contains(number3));
            Assert.IsTrue(_linkedList.Contains(number2));
        }
        [Test]
        public void RemoveLat_WhenTheLastRemainingElementIsRemovedTheQueueShouldBeEmpty()
        {
            int number1 = 1;

            _linkedList.AddLast(number1);

            _linkedList.RemoveLast();

            Assert.IsTrue(_linkedList.IsEmpty());
        }
    }
}
