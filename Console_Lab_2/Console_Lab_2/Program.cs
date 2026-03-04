using System;

namespace Console_Lab_2_ALGO
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.Write("\n+------------ Menu ------------+\n"
                              + "|1. Partition\n"
                              + "|2. Modified partition\n"
                              + "|3. Quick sorting\n"
                              + "|4. Randomized quick sorting\n"
                              + "|5. Coordinates\n"
                              + "|0. Exit\n"
                              + "+------------------------------+\n");

                choice = GetInt("Your choice: ");

                switch (choice)
                {
                    case 1:
                        FirstCase();
                        break;
                    case 2:
                        int[] numbers1 = new int[] { 8, 8, 8, 8, 8 };
                        ModifiedPartition(numbers1, 0, numbers1.Length - 1);
                        break;
                    case 3:
                        ThirdCase();
                        break;
                    case 4:
                        FourthCase();
                        break;
                    case 5:
                        FifthCase();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 0);
        }
        static int Partition(int[] arr, int left, int right)
        {
            right = arr.Length - 1;
            int pivot = arr[right];
            int i = left - 1;

            Console.Write("Original array: ");
            PrintArray(arr);

            Console.Write($"\nPivot element = {pivot}\n"
                + "\t\t\t   Sorting");

            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp; // Обмін елементів місцями

                    Console.Write($"\nStep {i + 1}: swapped {arr[i]} and {arr[j]}: ");
                    PrintArray(arr);
                }
            }
            Console.Write($"\nStep {i + 2}: swapping {arr[i + 1]} and {arr[right]}: ");
            (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);
            PrintArray(arr);
            return i + 1;
        }
        static void FirstCase()
        {
            int[] numbers = new int[] { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };
            Partition(numbers, 0, numbers.Length - 1);
            Console.WriteLine();
        }
        static int ModifiedPartition(int[] arr, int left, int right)
        {
            bool identicalElements = true;

            Console.Write("\nOriginal array: ");
            PrintArray(arr);

            // Перевірка чи елементи однакові
            for (int k = left + 1; k <= right; k++)
            {
                if (arr[k] != arr[left])
                {
                    identicalElements = false;
                    break;
                }
            }

            if (identicalElements)
            {
                int q = (left + right) / 2;
                Console.WriteLine($"\nAll elements are equal, q = {q}");
                return q;
            }

            // Звичайний Partition
            int pivot = arr[right];
            int i = left - 1;

            Console.Write($"\nPivot element = {pivot}\n"
                + "Sorting");

            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);

                    Console.Write($"\nStep {i + 1}: swapped {arr[i]} and {arr[j]}: ");
                    PrintArray(arr);
                }
            }
            Console.Write($"\nStep {i + 2}: swapping {arr[i + 1]} and {arr[right]}: ");
            (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);

            PrintArray(arr);

            return i + 1;
        }
        static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;

            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2]; // середній елемент

            while (i <= j)
            {
                // для сортування за спаданням
                while (arr[i] > pivot) i++;
                while (arr[j] < pivot) j--;

                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j)
                QuickSort(arr, left, j);
            if (i < right)
                QuickSort(arr, i, right);
        }
        static void ThirdCase()
        {
            int[] numbers2 = new int[] { 32, 23, 43, 56, 2, 4, 19, 12, 56, 67, 8, 1, 43 };
            Console.Write("\nOriginal array: ");
            PrintArray(numbers2);
            QuickSort(numbers2, 0, numbers2.Length - 1);
            Console.Write("\nSorted array:   ");
            PrintArray(numbers2);
            Console.WriteLine();
        }
        static void RandomizedQuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            Random random = new Random();

            // Випадковий pivot
            int randomIndex = random.Next(left, right + 1);
            int temp = arr[randomIndex];
            arr[randomIndex] = arr[right];
            arr[right] = temp;

            // Partition для незростаючого порядку
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] >= pivot)   // >= для спадання
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp;

            int pivotIndex = i + 1;

            // Рекурсивні виклики методу
            RandomizedQuickSort(arr, left, pivotIndex - 1);
            RandomizedQuickSort(arr, pivotIndex + 1, right);
        }
        static void FourthCase()
        {
            int[] numbers3 = new int[] { 5, 22, 12, 34, 27, 1, 9, 27, 54, 46, 6, 88, 8 };
            Console.Write("\nOriginal array: ");
            PrintArray(numbers3);
            RandomizedQuickSort(numbers3, 0, numbers3.Length - 1);
            Console.Write("\nSorted array:   ");
            PrintArray(numbers3);
            Console.WriteLine();
        }
        static void Task9(int[] arr, int left, int right)
        {
            left = 0;
            right = arr.Length - 1;
            int k = arr.Length / 2;   // індекс медіани
            Random rand = new Random();

            // QuickSelect 
            while (left <= right)
            {
                int pivotIndex = rand.Next(left, right + 1);

                // swap pivot з останнім
                int temp = arr[pivotIndex];
                arr[pivotIndex] = arr[right];
                arr[right] = temp;

                int pivot = arr[right];
                int i = left;

                for (int j = left; j < right; j++)
                {
                    if (arr[j] <= pivot)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        i++;
                    }
                }

                temp = arr[i];
                arr[i] = arr[right];
                arr[right] = temp;

                if (i == k)
                    break;
                else if (k < i)
                    right = i - 1;
                else
                    left = i + 1;
            }

            int optimalY = arr[k];

            // Обчислення сумарної довжини 
            int totalLength = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalLength += Math.Abs(arr[i] - optimalY);
            }

            Console.Write($"\nOptimal pipeline level Y = {optimalY}");
            Console.Write($"\nMinimal total sleeve length = {totalLength}\n");
        }
        static void FifthCase()
        {
            int[] numbers4 = new int[] { 45, 22, 8, 31, 7 };
            Console.Write("\nCoordinates at y: ");
            PrintArray(numbers4);
            Task9(numbers4, 0, numbers4.Length - 1);
        }
        static void PrintArray(int[] arr)
        {
            Console.Write(string.Join(", ", arr));
        }
        static int GetInt(string request)
        {
            int result;

            Console.Write(request);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Error: please enter a valid integer.");
                Console.Write(request);
            }
            return result;
        }
    }
}