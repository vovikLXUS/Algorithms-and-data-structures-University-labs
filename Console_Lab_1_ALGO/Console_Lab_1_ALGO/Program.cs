/*
        Написати програму мовою C# з можливістю вибору різних алгоритмів пошуку. Продемонструвати роботу ефективність 
(час виконання) програм на різних структурах даних (масив, лінійний зв’язаний список), з різними умовами, що забезпечують 
зменшення часу виконання. Навести аналіз отриманих результатів. Реалізувати алгоритми:
    * пошуку перебором елемента масиву, що дорівнює заданому значенню.
    * пошуку з бар'єром елемента масиву, що дорівнює заданому значенню.
    * бінарного пошуку елемента масиву рівного заданому значенню.
    * бінарного пошуку елемента масиву, рівного заданому значенню, в якій нове значення індексу m визначалося б 
      не як середнє значення між L і R, а згідно з правилом золотого перерізу.
 */
using System;
using System.Diagnostics;
using System.Text;

namespace Console_Lab_1_ALGO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Greet();

            bool isNumber;
            int choice, size, x;
            int[] numbers = GenerateArray(1000);

            do
            {
                Console.Write("\n-User's menu-\n"
                + "1. Create and fill array\n"
                + "2. Brute-force search\n"
                + "3. Barrier search\n"
                + "4. Binary search\n"
                + "5. Golden section binary search\n"
                + "Your choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("\n-Creating and filling array-"
                            + "\nEnter size of array: ");
                        size = int.Parse(Console.ReadLine());
                        Console.Write("Generated array: ");
                        numbers = GenerateArray(size);
                        PrintArray(numbers);
                        break;
                    case 2:
                        Console.Write("\n-Brute-force search (Linear search)-"
                            + "\nEnter element to search: ");
                        isNumber = int.TryParse(Console.ReadLine(), out x);
                        if (!isNumber)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                        int index = TimerForLinear(numbers, x);
                        break;
                    case 3:
                        Console.Write("\n-Barrier search-"
                            + "\nEnter element to search: ");
                        isNumber = int.TryParse(Console.ReadLine(), out x);
                        if (!isNumber)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                        int[] numbers1 = new int[numbers.Length + 1];
                        Array.Copy(numbers, numbers1, numbers.Length);
                        index = TimerForBarrier(numbers1, x);
                        break;
                    case 4:
                        Console.Write("\n-Binary search-"
                            + "\nEnter element to search: ");
                        isNumber = int.TryParse(Console.ReadLine(), out x);
                        if (!isNumber)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                        SortArray(numbers);
                        index = TimerForBinary(numbers, x);
                        break;
                    case 5:
                        Console.Write("\n-Golden section binary search-"
                            + "\nEnter element to search: ");
                        isNumber = int.TryParse(Console.ReadLine(), out x);
                        if (!isNumber)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                        SortArray(numbers);
                        index = TimerForGoldenSection(numbers, x);
                        break;
                    case 0:
                        Console.Write("\nExiting from program. Good luck!");
                        break;
                    default:
                        Console.Write("\nEntered incorrect variant, try again!");
                        break;
                } 
            } while (choice != 0);
        }
        static void Greet()
        {
            Console.WriteLine("Datsyshyn Volodymyr, 18 years"
                + "\n1 course, group IPZ-13(06)"
                + "\nvovadatsyshyn@knu.ua"
                + "\nAlgorithms and Data Structures.");
        }
        static int[] GenerateArray(int size)
        {
            Random random = new Random();
            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(-500, 500); 
            }
            return arr;
        }
        static void SortArray(int[] array)
        {
            Array.Sort(array);
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        // Метод лінійного пошуку   
        static int LinearSearch(int[] array, int x)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == x)
                return i;
            }
            return -1;
        }
        // Метод-кейс з підрахуванням часу алгоритму пошуку (лінійний пошук)
        static int TimerForLinear(int[] array, int x)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = LinearSearch(array, x);
            stopwatch.Stop();
            if (i != -1)
                Console.Write($"Element found at {i} position.\n");
            else
                Console.Write("Element not found.\n");
            Console.Write($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds:F5} ms.\n");
            return i;
        }
        // Метод бар'єрного пошуку
        static int BarrierSearch(int[] array, int x, int n)
        {
            array[n - 1] = x;
            int i = 0;

            while (array[i] != x)
            {
                i++;
            }
            return (i < n) ? i : -1;
        }
        // Метод-кейс з підрахуванням часу алгоритму пошуку (бар'єрний пошук)
        static int TimerForBarrier(int[] array, int x)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = BarrierSearch(array, x, array.Length);
            stopwatch.Stop();
            if (i != -1)
                Console.Write($"Element found at {i} position.\n");
            else
                Console.Write("Element not found.\n");
            Console.Write($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds:F5} ms.\n");
            return i;
        }
        // Метод бінарного пошуку
        static int BinarySearch(int[] array, int x)
        {
            int l = 0, 
                r = array.Length - 1;

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (array[m] == x) 
                    return m;
                if (array[m] < x) 
                    l = m + 1;
                else
                    r = m - 1;
            }
            return -1;
        }
        // Метод-кейс з підрахуванням часу бінарного пошуку
        static int TimerForBinary(int[] array, int x)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = BinarySearch(array, x);
            stopwatch.Stop();

            if (i != -1)
                Console.Write($"Element found at {i} position.\n");
            else
                Console.Write("Element not found.\n");
            Console.Write($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds:F5} ms.\n");
            return i;
        }
        // Метод бінарного пошуку за золотим перетином 
        static int GoldenSectionSearch(int[] array, int x)
        {
            int l = 0, 
                r = array.Length - 1;
            const double DP = 0.61804; // Divine proportion (DP) = 1 / phi

            while (l <= r)
            {
                int m = l + (int)((r - l) * DP);

                if (array[m] == x) 
                    return m;
                if (array[m] < x) 
                    l = m + 1;
                else 
                    r = m - 1;
            }
            return -1;
        }
        // Метод-кейс з підрахуванням часу алгоритму пошуку (золотий перетин)
        static int TimerForGoldenSection(int[] array, int x) 
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = GoldenSectionSearch(array, x);
            stopwatch.Stop();
            if (i != -1)
                Console.Write($"Element found at {i} position.\n");
            else
                Console.Write("Element not found.\n");
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds:F5} ms.");
            return i;
        }
    }
}