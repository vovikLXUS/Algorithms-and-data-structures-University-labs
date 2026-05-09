using System;

namespace ConsoleLab4_ASD.Tasks
{
    public class LinkedStack<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;

        // PUSH
        public void Push(T item)
        {
            Node newNode = new Node(item);
            newNode.Next = head;
            head = newNode;
        }

        // POP
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            T value = head.Data;
            head = head.Next;
            return value;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }
}