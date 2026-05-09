using System;
using System.Collections.Generic;

namespace ConsoleLab4_ASD.Tasks
{
    public class QueueUsingStacks<T>
    {
        private Stack<T> stackIn = new Stack<T>();
        private Stack<T> stackOut = new Stack<T>();

        // Додавання елемента (ENQUEUE)
        public void Enqueue(T item)
        {
            stackIn.Push(item);
        }

        // Видалення елемента (DEQUEUE)
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            // Якщо stackOut пустий — переносимо всі елементи
            if (stackOut.Count == 0)
            {
                while (stackIn.Count > 0)
                    stackOut.Push(stackIn.Pop());
            }

            return stackOut.Pop();
        }

        public bool IsEmpty()
        {
            return stackIn.Count == 0 && stackOut.Count == 0;
        }
    }
}