using System;

namespace Homework_05.Controller
{
    public class MyTask
    {
        /// <summary>
        /// Определяет минимальные по длине слова в строке
        /// </summary>
        /// <param name="line"> Строка слов </param>       
        public string ShortestWord(string line)
        {
            string[] words = line.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            AlgorithmBase.QuickSort(words);

            string str = words[0] + " ";

            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > words[0].Length)
                {
                    break;
                }
                else
                {
                    if (words[i] != words[i - 1])
                    {
                        str += words[i] + " ";
                    }
                }
            }

            return str;
        }

        /// <summary>
        /// Определяет максимальные по длине слова в строке
        /// </summary>
        /// <param name="line"> Строка слов </param>        
        public string LongestWord(string line)
        {
            string[] words = line.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            AlgorithmBase.QuickSort(words);
            string str = words[words.Length - 1] + " ";

            for (int i = words.Length - 2; i >= 0; i--)
            {
                if (words[i].Length < words[words.Length - 1].Length)
                {
                    break;
                }
                else
                {
                    if (words[i + 1] != words[i])
                    {
                        str += words[i] + " ";
                    }
                }
            }

            return str;
        }

        /// <summary>
        /// Удаляет повторяющиеся попарные одинаковые символы в строке
        /// </summary>
        /// <param name="line"> Строка слов </param>
        public string DeleteDuplicateCharacters(string line)
        {
            string str = Convert.ToString(line[0]);

            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] != line[i - 1])
                {
                    str += line[i];
                }
            }

            return str;
        }

        /// <summary>
        /// Проверяет является ли введённая последовательность арифметической или геометрической прогрессией
        /// </summary>
        /// <param name="items"> Последовательность чисел </param>        
        public string Progression(params double[] items)
        {
            bool ArithmeticProgression = true;
            bool GeometricProgression = true;

            if (items.Length >= 3)
            {
                for (int i = 1; i < items.Length - 1; i++)
                {
                    ArithmeticProgression = ArithmeticProgression && (items[i] == (items[i + 1] + items[i - 1]) / 2);

                    GeometricProgression = GeometricProgression && (items[i] * items[i] == items[i + 1] * items[i - 1]);
                }

                if (ArithmeticProgression)
                {
                    return "Данная последовательность является арифметической прогрессией.";
                }

                if (GeometricProgression)
                {
                    return "Данная последовательность является геометрической прогрессией.";
                }

                return "Данная последовательность не является арифметической или геометрической прогрессией.";
            }

            return "В последовательности не может быть меньше трёх членов";
        }

        /// <summary>
        /// Функция Аккермана
        /// </summary>
        public ulong Ackkerman(ulong m, ulong n)
        {
            if (m == 0) return n + 1;
            if (n == 0 && m > 0) return Ackkerman(m - 1, 1);
            
            return Ackkerman(m - 1, Ackkerman(m,n - 1));            
        }
    }
}
