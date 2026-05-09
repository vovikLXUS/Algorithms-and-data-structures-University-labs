using System;

namespace ConsoleLab4_ASD.Tasks
{
    public class LinkedQueue<T>
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
        private Node tail;

        // ENQUEUE
        public void Enqueue(T item)
        {
            Node newNode = new Node(item);

            if (tail != null)
                tail.Next = newNode;

            tail = newNode;

            if (head == null)
                head = newNode;
        }

        // DEQUEUE
        public T Dequeue()
        {
            if (head == null)
                throw new InvalidOperationException("Queue is empty");

            T value = head.Data;
            head = head.Next;

            if (head == null)
                tail = null;

            return value;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }
}