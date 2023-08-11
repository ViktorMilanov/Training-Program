namespace Hristo.DataStructures
{
    public class MyLinkedList<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        private int count;

        public int Count { get { return count; } }

        public void Add(T value)
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

        public bool Contains(T value)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public Node<T> Find(T value)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        public class Node<T>
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
