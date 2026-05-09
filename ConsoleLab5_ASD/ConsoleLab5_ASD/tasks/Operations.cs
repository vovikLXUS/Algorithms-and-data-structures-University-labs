using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab5_ASD.tasks
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public Node Parent;

        public Node(int value, Node parent)
        {
            Data = value;
            Left = null;
            Right = null;
            Parent = parent;
        }
    }
    public class BinaryTree
    {
        public Node Root;

        // Прямий обхід (Pre-order): Корінь - Ліворуч - Праворуч
        public void PreOrder(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.Data + " "); // Відвідуємо корінь
            PreOrder(node.Left); // Рекурсія ліворуч
            PreOrder(node.Right); // Рекурсія праворуч
        }

        // Зворотний обхід (Post-order): Ліворуч - Праворуч - Корінь
        public void PostOrder(Node node)
        {
            if (node == null)
                return;

            PostOrder(node.Left); // Рекурсія ліворуч
            PostOrder(node.Right); // Рекурсія праворуч
            Console.Write(node.Data + " "); // Відвідуємо корінь
        }
    }
    public class Operations
    {
        public void InOrderWithStack(Node root)
        {
            if (root == null)
                return;

            Stack<Node> stack = new Stack<Node>();
            Node current = root;

            while (current != null || stack.Count > 0)
            {
                // Спускаємося якомога лівіше, зберігаючи шлях у стеку
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                // Дістаємо вузол зі стека (це найлівіший доступний вузол)
                current = stack.Pop();
                Console.Write(current.Data + " ");

                // Переходимо до правого піддерева
                current = current.Right;
            }
        }
        public void InOrderMorris(Node root)
        {
            Node current = root;

            while (current != null)
            {
                if (current.Left == null)
                {
                    // Якщо лівого вузла немає, виводимо поточний і йдемо праворуч
                    Console.Write(current.Data + " ");
                    current = current.Right;
                }
                else
                {
                    // Шукаємо попередника в симетричному порядку
                    Node predecessor = current.Left;
                    while (predecessor.Right != null && predecessor.Right != current)
                    {
                        predecessor = predecessor.Right;
                    }

                    // Перевірка рівності покажчиків (Ключовий момент)
                    if (predecessor.Right == null)
                    {
                        // Створюємо тимчасову нитку до поточного вузла
                        predecessor.Right = current;
                        current = current.Left;
                    }
                    else
                    {
                        // Ми вже тут були, тому розриваємо нитку, виводимо корінь і йдемо вправо
                        predecessor.Right = null;
                        Console.Write(current.Data + " ");
                        current = current.Right;
                    }
                }
            }
        }
        public Node Root;

        // Рекурсивна версія TREE-MINIMUM
        // Ідемо ліворуч, поки не знайдемо вузол, у якого немає лівого нащадка
        public Node TreeMinimum(Node node)
        {
            if (node == null)
                return null;

            if (node.Left == null)
                return node; // Ми знайшли найлівіший вузол

            return TreeMinimum(node.Left); // Рекурсивний крок ліворуч
        }

        // Рекурсивна версія TREE-MAXIMUM
        // Ідемо праворуч, поки не знайдемо вузол, у якого немає правого нащадка
        public Node TreeMaximum(Node node)
        {
            if (node == null)
                return null;

            if (node.Right == null)
                return node; // Ми знайшли найправіший вузол

            return TreeMaximum(node.Right); // Рекурсивний крок праворуч
        }

        // Повертає вузол з найбільшим ключем, який менший за key вузла x
        public Node TreePredecessor(Node x)
        {
            if (x == null) return null;

            // Якщо є ліве піддерево, попередник — це максимум у ньому
            if (x.Left != null)
                return TreeMaximum(x.Left);

            // Якщо лівого піддерева немає, йдемо вгору до першого повороту праворуч
            Node y = x.Parent;
            while (y != null && x == y.Left)
            {
                x = y;
                y = y.Parent;
            }
            return y;
        }

        // Рекурсивна версія TREE-INSERT
        public Node TreeInsert(Node root, int key, Node parent = null)
        {
            // Якщо дійшли до порожнього місця — створюємо новий вузол
            if (root == null)
                return new Node(key, parent);

            if (key < root.Data)
                root.Left = TreeInsert(root.Left, key, root);
            else if (key > root.Data)
                root.Right = TreeInsert(root.Right, key, root);

            return root;
        }
    }
}
