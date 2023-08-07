namespace VM.DataStructures
{
    public class CustomQueue<T>
    {
        private class Node
        {
            public T? value;
            public Node? next;
        }

        private Node? front, rear;
        public int Count { get; private set; }
        public CustomQueue()
        {
            front = rear = null;
        }
        public bool IsEmpty() => front == null || rear == null;

        public void Clear()
        {
            front = rear = null;
            Count = 0;
        }
        public void Enqueue(T input)
        {
            Node node = new();
            node.value = input;

            if (rear == null)
            {
                front = rear = node;
            }
            else
            {
                rear.next = node;
                rear = node;
            }
            Count++;
        }
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is Empty");
            Node node = front;
            front = front.next;
            if (front == null)
            {
                rear = null;
            }
            Count--;
            return node.value;
        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is Empty");
            }
            return front.value;
        }
        public bool Contains(T item)
        {
            if (IsEmpty())
            {
                return false;
            }
            Node temp = front;
            if (temp.value.Equals(item))
            {
                return true;
            }
            while (temp.next != null)
            {
                temp = temp.next;
                if (temp.value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
