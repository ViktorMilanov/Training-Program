using System.Collections;

namespace VM.DataStructures
{
    public class Node<T>
    {
        public T? value;
        public Node<T>? next;
        public Node<T>? prev;
    }
    public class CustomLinkedList<T> : IEnumerator<T>
    {
        private Node<T>? front, rear;
        public int Count { get; private set; }

        private Node<T>? currentNode;
        public T Current
        {
            get
            {
                if (currentNode == null)
                {
                    throw new InvalidOperationException("Enumeration has not started.");
                }

                return currentNode.value!;
            }
        }

        object IEnumerator.Current => Current;

        public CustomLinkedList()
        {
            front = rear = null;
        }

        public void Clear(){
            front = rear = null;
            Count = 0;
            }

        public bool IsEmpty() => front == null || rear == null;

        public void AddFirst(T input)
        {
            Node<T> node = new();
            node.value = input;
            if (front == null)
            {
                front = rear = node;
            }
            else
            {
                front.prev = node;
                node.next = front;
                front = node;
            }
            Count++;

        }
        public void AddLast(T input)
        {
            Node<T> node = new();
            node.value = input;
            if (rear == null)
            {
                front = rear = node;
            }
            else
            {
                rear.next = node;
                node.prev = rear;
                rear = node;
            }
            Count++;
        }
        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (newNode.next != null || newNode.prev != null)
            {
                throw new InvalidOperationException("This node already exist in linked list");
            }
            if (!ContainsNode(node))
            {
                throw new InvalidOperationException("This node doesn't exist in linked list");
            }
            if (rear == node)
            {
                node.next = newNode;
                newNode.prev = node;
                rear = newNode;
            }
            else
            {
                var next = node.next;
                node.next = newNode;
                newNode.prev = node;
                newNode.next = next;
                next.prev = newNode;
            }
            Count++;
        }
        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (newNode.next != null || newNode.prev != null)
            {
                throw new InvalidOperationException("This node already exist in linked list");
            }
            if (!ContainsNode(node))
            {
                throw new InvalidOperationException("This node doesn't exist in linked list");
            }
            if (front == node)
            {
                node.prev = newNode;
                newNode.next = node;
                front = newNode;
            }
            else
            {
                var prev = node.prev;
                node.prev = newNode;
                newNode.next = node;
                newNode.prev = prev;
                prev.next = newNode;
            }
            Count++;
        }
        public bool Contains(T item)
        {
            return Find(item) != null;
        }
        public Node<T>? Find(T item)
        {
            if (IsEmpty())
            {
                return null;
            }
            Node<T> temp = front;
            if (temp.value.Equals(item))
            {
                return temp;
            }
            while (temp.next != null)
            {
                temp = temp.next;
                if (temp.value.Equals(item))
                {
                    return temp;
                }
            }
            return null;
        }
        private bool ContainsNode(Node<T> node)
        {
            if (IsEmpty())
            {
                return false;
            }
            Node<T> temp = front;
            if (temp == node)
            {
                return true;
            }
            while (temp.next != null)
            {
                temp = temp.next;
                if (temp == node)
                {
                    return true;
                }
            }
            return false;
        }
        public Node<T>? FindLast(T item)
        {
            if (IsEmpty())
            {
                return null;
            }
            Node<T> temp = rear;
            if (temp.value.Equals(item))
            {
                return temp;
            }
            while (temp.prev != null)
            {
                temp = temp.prev;
                if (temp.value.Equals(item))
                {
                    return temp;
                }
            }
            return null;
        }
        public void Remove(T item)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Linked List is Empty");
            }
            Node<T> temp = front;
            if((front == rear) && front.value.Equals(item))
            {
                Clear();
                return;
            }
            if (temp.value.Equals(item))
            {
                front = front.next;
                Count--;
            }
            while (temp.next != null)
            {
                temp = temp.next;
                if (temp.value.Equals(item))
                {
                    if (temp.next == null)
                    {
                        rear.prev.next = null;
                        rear = rear.prev;
                        Count--;
                        return;
                    }
                    temp.next.prev = temp.prev;
                    temp.prev.next = temp.next;
                    Count--;
                    return;
                }
            }
        }
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Linked List is Empty");
            }
            if (front == rear)
            {
                Clear();
                return;
            }
            front = front.next;
            Count--;
        }
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Linked List is Empty");
            }
            if (front == rear)
            {
                Clear();
                return;
            }
            rear.prev.next = null;
            rear = rear.prev;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            currentNode = null;

            while (MoveNext())
            {
                yield return currentNode!.value;
            }

            currentNode = null;
        }

        public bool MoveNext()
        {
            if (currentNode == null)
            {
                return false;
            }

            currentNode = currentNode.next;
            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = null;
        }

        public void Dispose()
        {
            // No additional cleanup needed in this case because i dont have any external
            // resources that require cleanup like database data stored in my program
        }
    }
}
