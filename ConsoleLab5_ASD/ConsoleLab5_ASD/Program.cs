using System;
using ConsoleLab5_ASD.tasks;

namespace ConsoleLab5_ASD
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            BinaryTree tree = new BinaryTree();
            Operations ops = new Operations();

            // --- Task 1 & 6: Побудова дерева за допомогою TREE-INSERT ---
            // Створюємо бінарне дерево пошуку з ключів: {1, 4, 5, 10, 16, 17, 21}
            // Почнемо з 10, щоб дерево було збалансованим (висота 2)
            int[] keys = { 10, 4, 17, 1, 5, 16, 21 };
            foreach (var key in keys)
            {
                tree.Root = ops.TreeInsert(tree.Root, key);
            }

            // --- Task 2: Рекурсивні обходи (Прямий та Зворотний) ---
            Console.WriteLine("\n--- Task 2: Рекурсивні обходи ---");
            Console.Write("Прямий обхід (Pre-order):   ");
            tree.PreOrder(tree.Root);

            Console.Write("\nЗворотний обхід (Post-order): ");
            tree.PostOrder(tree.Root);
            Console.WriteLine();

            // --- Task 3: Нерекурсивні обходи (Симетричний порядок) ---
            Console.WriteLine("\n--- Task 3: Нерекурсивні обходи (In-order) ---");
            Console.Write("З використанням стека: ");
            ops.InOrderWithStack(tree.Root);

            Console.Write("\nАлгоритм Морріса:      ");
            ops.InOrderMorris(tree.Root);
            Console.WriteLine();

            // --- Task 4: Пошук Мінімуму та Максимуму ---
            Console.WriteLine("\n--- Task 4: Рекурсивні екстремуми ---");
            Node min = ops.TreeMinimum(tree.Root);
            Node max = ops.TreeMaximum(tree.Root);
            Console.WriteLine($"Мінімальний елемент: {min?.Data}");
            Console.WriteLine($"Максимальний елемент: {max?.Data}");

            // --- Task 5: Пошук Попередника (TREE-PREDECESSOR) ---
            Console.WriteLine("\n--- Task 5: Пошук попередника ---");

            // Приклад 1: Попередник для кореня (10)
            Node predecessorForRoot = ops.TreePredecessor(tree.Root);
            Console.WriteLine($"Попередник для {tree.Root.Data}: {predecessorForRoot?.Data}");

            // Приклад 2: Попередник для вузла 16 (має бути 10)
            // Шукаємо вузол 16 у дереві
            Node node16 = tree.Root.Right.Left;
            Node predecessorFor16 = ops.TreePredecessor(node16);
            Console.WriteLine($"Попередник для {node16.Data}: {predecessorFor16?.Data}");

            // Приклад 3: Попередник для найменшого вузла (має бути null)
            Node predecessorForMin = ops.TreePredecessor(min);
            Console.WriteLine($"Попередник для мінімуму ({min.Data}): " + (predecessorForMin == null ? "відсутній" : predecessorForMin.Data.ToString()));
        }
    }
}
