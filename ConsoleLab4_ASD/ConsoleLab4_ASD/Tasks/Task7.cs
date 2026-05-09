using System;
using System.Collections.Generic;

namespace ConsoleLab4_ASD.Tasks
{
    public class StackUsingQueues<T>
    {
        private Queue<T> q1 = new Queue<T>();
        private Queue<T> q2 = new Queue<T>();

        // PUSH
        public void Push(T item)
        {
            q1.Enqueue(item);
        }

        // POP
        public T Pop()
        {
            if (q1.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            // Переносимо всі елементи, крім останнього
            while (q1.Count > 1)
                q2.Enqueue(q1.Dequeue());

            T result = q1.Dequeue();

            // Міняємо черги місцями
            var temp = q1;
            q1 = q2;
            q2 = temp;

            return result;
        }

        public bool IsEmpty()
        {
            return q1.Count == 0;
        }
    }
}