using ConsoleApp1;
using System;

namespace Console_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstSearch();
            SecondSearch();
        }
        static int Task1(string str, string img) // Direct search
        {
            while (str.Length < img.Length)
            {
                Console.Write("\nIncorrect input. The substring must be shorter than string.");
                Helper.GetString("\nEnter string correctly: ");
            }
            // Проходимо по всьому рядку
            for (int i = 0; i <= str.Length - img.Length; i++)
            {
                int j;
                // Порівнюємо символи
                for (j = 0; j < img.Length; j++)
                {
                    if (str[i + j] != img[j])
                        break;
                }
                if (j == img.Length) // Якщо співпали
                    return i;
            }
            return -1;
        }
        static void FirstSearch()
        {
            Console.Write("----- Direct search -----\n");
            string str = Helper.GetString("Enter your string: "),
                   img = Helper.GetString("Enter your substring: ");

            int index = Task1(str, img);

            if (index != -1)
                Console.WriteLine($"Your substring is found on {index + 1} position.");
            else
                Console.WriteLine("Your substring is not found.");
        }
        static int[] PrefixFunc(string chars)
        {
            int[] prefix = new int[chars.Length];
            prefix[0] = 0; // Для першого символу рядка префікс завжди 0
                           // бо нема підрядка, який водночас є префіксом і суфіксом

            int j = 0; // зберігаємо довжину поточного співпадаючого префікса

            for (int i = 1; i < chars.Length; i++) // починаємо з 2го символу
            {
                // Якщо символи не співпадають - зменшуємо довжину префікса
                while (j > 0 && chars[i] != chars[j]) 
                {
                    j = prefix[j - 1];
                }
                if (chars[i] == chars[j]) // якщо співпали
                    j++; // збвльшуємо довжину знайденого префікса

                prefix[i] = j; // записуємо значення
            }
            return prefix;
        }
        static int Task2(string str, string img) // Knuth - Morris - Pratt search
        {
            while (str.Length < img.Length)
            {
                Console.Write("\nIncorrect input. The substring must be shorter than string.");
                Helper.GetString("\nEnter string correctly: ");
            }

            int[] prefix = PrefixFunc(str); // Отримуємо префікс для підрядка
            int i = 0, 
                j = 0;

            while (i < str.Length)
            {
                if (str[i] == img[j])
                {
                    i++;
                    j++;

                    if (j == img.Length)
                        return i - j;
                }
                else
                {
                    // якщо є невідповідність, використовуємо таблицю префіксів
                    // щоб змістити підрядок без повторної перевірки
                    if (j > 0) 
                        j = prefix[j - 1];
                    else // якщо j = 0, продовжуємо рухатись далі
                        i++;
                }
            }

            return -1;
        }
        static void SecondSearch()
        {
            Console.Write("----- Knuth-Morris-Pratt search -----\n");
            string str = Helper.GetString("Enter your string: "),
                     img = Helper.GetString("Enter your substring: ");

            int index = Task2(str, img);

            if (index != -1)
                Console.WriteLine($"Your substring is found on {index + 1} position.");
            else
                Console.WriteLine("Your substring is not found.");
        }
    }
}