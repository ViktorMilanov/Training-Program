namespace Hristo.DataStructures
{
    public class MyQueue<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        private int count;

        public int Count { get { return count; } }

        public void Enqueue(T value)
        {
            var newNode = new Node<T>(value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T value = head.Value;
            head = head.Next;

            if (head == null)
            {
                tail = null;
            }

            count--;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return head.Value;
        }

        public bool IsEmpty()
        {
            return head == null;
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
