namespace VM.DataStructures
{
    public class CustomStack<T>
    {
        private class Node
        {
            public T? value;
            public Node? previousElement;
        }

        private Node? top;
        public int Count { get; private set; }
        public CustomStack()
        {
            top = null;
        }
        public void Clear()
        {
            top = null;
            Count = 0;
        }
        public bool IsEmpty() => top == null;



        public void Push(T input)
        {
            Node node = new();
            node.value = input;
            node.previousElement = top;
            top = node;
            Count++;
        }
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is Empty");

            T returnValue = top.value;
            top = top.previousElement;
            Count--;
            return returnValue;
        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            return top.value;
        }
        public bool Contains(T item)
        {
            if (IsEmpty())
            {
                return false;
            }
            Node temp = top;
            if (temp.value.Equals(item))
            {
                return true;
            }
            while (temp.previousElement != null)
            {
                temp = temp.previousElement;
                if (temp.value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}