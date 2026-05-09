using System;

namespace ConsoleLab4_ASD.Tasks
{
    public class ArrayDeque<T>
    {
        private readonly T[] data;
        private int front;   // індекс першого елемента
        private int rear;    // індекс наступної позиції після останнього елемента
        private int count;   // кількість елементів

        public ArrayDeque(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be a positive value");

            data = new T[capacity];
            front = 0;
            rear = 0;
            count = 0;
        }

        public bool IsEmpty => count == 0;
        public bool IsFull => count == data.Length;

        // Вставка на початок
        public void AddFront(T item)
        {
            if (IsFull)
                throw new InvalidOperationException("Deque is full");

            front = (front - 1 + data.Length) % data.Length;
            data[front] = item;
            count++;
        }

        // Вставка в кінець
        public void AddBack(T item)
        {
            if (IsFull)
                throw new InvalidOperationException("Deque is full");

            data[rear] = item;
            rear = (rear + 1) % data.Length;
            count++;
        }

        // Видалення з початку
        public T RemoveFront()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Deque is empty");

            T item = data[front];
            front = (front + 1) % data.Length;
            count--;
            return item;
        }

        // Видалення з кінця
        public T RemoveBack()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Deque is empty");

            rear = (rear - 1 + data.Length) % data.Length;
            T item = data[rear];
            count--;
            return item;
        }
    }
}
