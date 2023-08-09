namespace Hristo.DataStructures
{
    public class MyStack<T>
    {
        private Node<T>? top;
        private int count;

        public int Count { get { return count; } }

        public void Push(T value)
        {
            var newNode = new Node<T>(value);
            newNode.Next = top;
            top = newNode;
            count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T value = top.Value;
            top = top.Next;
            count--;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return top.Value;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        private class Node<T>
        {
            public T Value { get; }
            public Node<T> Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }
    }
}