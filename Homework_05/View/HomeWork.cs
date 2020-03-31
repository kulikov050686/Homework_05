using System;
using Homework_05.Controller;

namespace Homework_05.View
{
    public class HomeWork
    {
        /// <summary>
        /// Завершение программы
        /// </summary>
        bool Exit;

        /// <summary>
        /// Конструктор домашнего задания
        /// </summary>
        public HomeWork()
        {
            Exit = false;
        }

        /// <summary>
        /// Запуск приложения
        /// </summary>
        public void run()
        {
            while (!Exit)
            {
                startMenu();
            }
        }

        /// <summary>
        /// Стартовое меню
        /// </summary>
        void startMenu()
        {
            string[] itensMenu = new string[] { "Задание 1",
                                                "Задание 2",
                                                "Задание 3",
                                                "Задание 4",
                                                "Задание 5",
                                                "Выход" };

            NewMenu menu = new NewMenu(itensMenu, "Выбирите пункт меню");

            switch (menu.selectedMenuItem())
            {
                case 0:
                    Task_1();
                    break;
                case 1:
                    Task_2();
                    break;
                case 2:
                    Task_3();
                    break;
                case 3:
                    Task_4();
                    break;
                case 4:
                    Task_5();
                    break;
                case 5:
                    Exit = true;
                    break;
            }
        }

        /// <summary>
        /// Задание 1
        /// </summary>
        void Task_1()
        {
            string[] itensMenu = new string[] { "Умножение матрицы на число",
                                                "Сложение матриц",
                                                "Вычитание матриц",
                                                "Умножение матриц",
                                                "Вычисление детерминанта"};

            MenuController menu = new MenuController(itensMenu);
            MatrixOperations matrixOperations = new MatrixOperations();

            switch (menu.selectedMenuItem())
            {
                case 0:
                    matrixOperations.show(0);
                    Console.ReadKey();
                    break;
                case 1:
                    matrixOperations.show(1);
                    Console.ReadKey();
                    break;
                case 2:
                    matrixOperations.show(2);
                    Console.ReadKey();
                    break;
                case 3:
                    matrixOperations.show(3);
                    Console.ReadKey();
                    break;
                case 4:
                    matrixOperations.show(4);
                    Console.ReadKey();
                    break;
            }
        }

        /// <summary>
        /// Задание 2
        /// </summary>
        void Task_2()
        {
            Console.Clear();
            Console.Write("Введите строку: ");

            string str = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Строка неможет быть пустой!!!");
            }
            else
            {
                MyTask task = new MyTask();
 
                if(task.ShortestWord(str).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length >= 2)
                {
                    Console.WriteLine("Самые короткие слова в строке: " + task.ShortestWord(str));
                }
                else
                {
                    Console.WriteLine("Самое короткое слово в строке: " + task.ShortestWord(str));
                }

                if (task.LongestWord(str).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length >= 2)
                {
                    Console.WriteLine("Самые длинные слова в строке: " + task.LongestWord(str));
                }
                else
                {
                    Console.WriteLine("Самое длинное слово в строке: " + task.LongestWord(str));
                }                
            }           

            Console.ReadKey();
        }

        /// <summary>
        /// Задание 3
        /// </summary>
        void Task_3()
        {
            Console.Clear();
            Console.Write("Введите строку: ");

            string str = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Строка неможет быть пустой!!!");
            }
            else
            {
                str = str.ToUpper();

                MyTask task = new MyTask();

                Console.WriteLine(" " + task.DeleteDuplicateCharacters(str));

            }

            Console.ReadKey();
        }

        /// <summary>
        /// Задание 4
        /// </summary>
        void Task_4()
        {
            Console.Clear();
            Console.Write("Введите через пробел последовательность чисел (не менее трёх): ");
            string str = Console.ReadLine();
            bool Error = true;

            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Последовательность неможет быть пустой!!!");
            }
            else 
            {
                string[] NumberStr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                double[] Number = new double[NumberStr.Length];

                for (int i = 0; i < NumberStr.Length; i++)
                {
                    Error = Error && double.TryParse(NumberStr[i], out Number[i]);
                }

                if (Error)
                {
                    MyTask task = new MyTask();

                    Console.WriteLine(task.Progression(Number));
                }
                else
                {
                    Console.WriteLine("Ошибка ввода данных!!!");
                }
            }            

            Console.ReadKey();
        }

        /// <summary>
        /// Задание 5
        /// </summary>
        void Task_5()
        {
            Console.Clear();
            Console.WriteLine("Функция Аккермана");
            Console.Write("Введите n (не болле 5): ");
            string strN = Console.ReadLine();
            Console.Write("Введите m (не более 3): ");
            string strM = Console.ReadLine();
            uint N = 0;
            uint M = 0;

            if(uint.TryParse(strN, out N) && uint.TryParse(strM, out M))
            {
                if(N <= 5 && M <= 3)
                {
                    MyTask task = new MyTask();

                    Console.WriteLine($"Значение функции Аккермана равно: {task.Ackkerman(M,N)}");
                }
                else
                {
                    Console.WriteLine("Диапазон ввода данных превышен!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных!!!");
            }

            Console.ReadKey();
        }
    }
}
