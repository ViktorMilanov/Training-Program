using NUnit.Framework;
using System;

namespace VM.DataStructures.UnitTests
{
    public class CustomStackTests
    {
        private CustomStack<int> _stack = null!;
        [SetUp]
        public void Setup()
        {
            _stack = new();
        }

        [Test]
        public void Push_ShouldAddNewElementAtTheEnd()
        {
            int number = 1;

            _stack.Push(number);

            Assert.AreEqual(1, _stack.Count);
            Assert.IsTrue(_stack.Contains(number));
        }
        [Test]
        public void PoP_ShouldThrowErrorIfTheStackIsEmpty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
               {
                   _stack.Pop();
               });
            StringAssert.Contains("Stack is Empty", ex.Message.ToString());
        }
        [Test]
        public void PoP_ShouldRemoveTheLastAddedElement()
        {
            int number1 = 1;
            int number2 = 2;

            _stack.Push(number1);
            _stack.Push(number2);

            Assert.AreEqual(number2, _stack.Pop());
            Assert.AreEqual(1, _stack.Count);
            Assert.IsTrue(_stack.Contains(number1));
            Assert.IsFalse(_stack.Contains(number2));
        }
        [Test]
        public void Peek_ShouldThrowErrorIfTheStackIsEmpty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                _stack.Peek();
            });
            StringAssert.Contains("Stack is Empty", ex.Message.ToString());
        }
        [Test]
        public void Peek_ShouldReturnTheLastAddedElement()
        {
            int number1 = 1;
            int number2 = 2;

            _stack.Push(number1);
            _stack.Push(number2);

            Assert.AreEqual(number2, _stack.Peek()); ;
        }
        [Test]
        public void Clear_ShouldRemoveAllElements()
        {
            int number1 = 1;
            int number2 = 2;

            _stack.Push(number1);
            _stack.Push(number2);
            _stack.Clear();

            Assert.IsTrue(_stack.IsEmpty());
        }
        [Test]
        public void IsEmpty_ShouldReturnTrueIfThereIsntElementsInTheStack()
        {
            Assert.IsTrue(_stack.IsEmpty());
        }
        [Test]
        public void IsEmpty_ShouldReturnFalseIfThereIsElementsInTheStack()
        {
            int number1 = 1;
            int number2 = 2;

            _stack.Push(number1);
            _stack.Push(number2);

            Assert.IsFalse(_stack.IsEmpty());
        }
        [Test]
        public void Contains_ShouldReturnFalseIfTheStackIsEmpty()
        {
            Assert.IsFalse(_stack.Contains(1));
        }
        [Test]
        public void Contains_ShouldReturnTrueIfSearchedElementIsFirstElementInTheStack()
        {
            int number1 = 1;
            int number2 = 2;

            _stack.Push(number1);
            _stack.Push(number2);

            Assert.IsTrue(_stack.Contains(1));
        }
        [Test]
        public void Contains_ShouldReturnTrueIfSearchedElementIsAnyElementInTheStack()
        {
            int number1 = 1;
            int number2 = 2;

            _stack.Push(number1);
            _stack.Push(number2);

            Assert.IsTrue(_stack.Contains(2));
        }
        [Test]
        public void Contains_ShouldReturnFalseIfSearchedElementIsntInTheStack()
        {
            int number1 = 1;
            int number2 = 2;

            _stack.Push(number1);
            _stack.Push(number2);

            Assert.IsFalse(_stack.Contains(3));
        }
    }
}