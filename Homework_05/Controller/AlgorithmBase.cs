using System;

namespace Homework_05.Controller
{
    public static class AlgorithmBase
    {
        /// <summary>
        /// Сортировка массива из строк по длинам строк методом пузырька
        /// </summary>
        /// <param name="items"> Массив сортируемых строк </param>
        public static void BubbleSort(string[] items)
        {
            int count = items.Length;
            string temp;

            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    int a = items[i].Length;
                    int b = items[j].Length;

                    if (a > b)
                    {
                        temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }                
            }            
        }

        /// <summary>
        /// Сортировка массива из строк по длинам строк методом быстрой сортировки
        /// </summary>
        /// <param name="items"> Массив сортируемых строк </param>
        public static void QuickSort(string[] items)
        {
            int start = 0;
            int end = items.Length - 1;

            Quick(items, start, end);
        }

        /// <summary>
        /// Перестановка элементов массива
        /// </summary>
        /// <param name="items"> Массив строк </param>
        /// <param name="start"> Индекс начального элемента </param>
        /// <param name="end"> Индекс конечного элемента </param>
        static int Partition(string[] items, int start, int end)
        {
            int marker = start;
            string temp;

            for (int i = start; i < end; i++)
            {
                int a = items[i].Length;
                int b = items[end].Length;

                if (a < b)
                {
                    temp = items[marker];
                    items[marker] = items[i];
                    items[i] = temp;
                    marker += 1;
                }
            }

            temp = items[marker];
            items[marker] = items[end];
            items[end] = temp;

            return marker;            
        }

        /// <summary>
        /// Рекурсивная функция сортировки
        /// </summary>
        /// <param name="items"> Массив строк </param>
        /// <param name="start"> Индекс начального элемента </param>
        /// <param name="end"> Индекс конечного элемента </param>
        static void Quick(string[] items, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = Partition(items, start, end);
            Quick(items, start, pivot - 1);
            Quick(items, pivot + 1, end);
        }
    }
}
