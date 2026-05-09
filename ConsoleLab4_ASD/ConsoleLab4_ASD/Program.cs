using System;
using System.Text;
using ConsoleLab4_ASD.Tasks;

namespace ConsoleLab4_ASD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ArrayDeque<int> deque = new ArrayDeque<int>(5);
            var queue = new QueueUsingStacks<int>();
            var stack = new StackUsingQueues<int>();
            var linkedStack = new LinkedStack<int>();
            var linkedQueue = new LinkedQueue<int>();

            // Task5 - Deque
            deque.AddBack(10);
            deque.AddBack(20);
            deque.AddFront(5);

            Console.WriteLine(deque.RemoveFront()); // 5
            Console.WriteLine(deque.RemoveBack());  // 20
            Console.WriteLine(deque.RemoveFront()); // 10

            // Task6 - Queue using Stacks
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine(queue.Dequeue()); // 1
            Console.WriteLine(queue.Dequeue()); // 2

            // Task7 - Stack using Queues
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine(stack.Pop()); // 30
            Console.WriteLine(stack.Pop()); // 20

            // Task8 - Linked Stack
            linkedStack.Push(5);
            linkedStack.Push(10);
            linkedStack.Push(15);

            Console.WriteLine(linkedStack.Pop()); // 15
            Console.WriteLine(linkedStack.Pop()); // 10

            // Task9 - Linked Queue
            linkedQueue.Enqueue(100);
            linkedQueue.Enqueue(200);
            linkedQueue.Enqueue(300);

            Console.WriteLine(linkedQueue.Dequeue()); // 100
            Console.WriteLine(linkedQueue.Dequeue()); // 200
        }
    }
}