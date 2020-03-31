using System;
using Homework_05.Model;

namespace Homework_05.Controller
{
    public class MatrixOperations
    {
        /// <summary>
        /// Количество строк 1-й матрицы
        /// </summary>
        int Row_1;

        /// <summary>
        /// Количество колонок 1-й матрицы
        /// </summary>
        int Column_1;

        /// <summary>
        /// Количество строк 2-й матрицы 
        /// </summary>
        int Row_2;

        /// <summary>
        /// Количество колонок 2-й матрицы
        /// </summary>
        int Column_2;

        /// <summary>
        /// Минимальное количество строк матрицы
        /// </summary>
        const int minRow = 1;

        /// <summary>
        /// Максимальное количество строк матрицы
        /// </summary>
        const int maxRow = 10;

        /// <summary>
        /// Минимальное количество колонок матрицы
        /// </summary>
        const int minColumn = 1;

        /// <summary>
        /// Максимальное количество колонок матрицы
        /// </summary>
        const int maxColumn = 10;

        /// <summary>
        /// Первая матрица
        /// </summary>
        Matrix A;

        /// <summary>
        /// Вторая матрица
        /// </summary>
        Matrix B;

        /// <summary>
        /// Контроллер по работе с матрицами
        /// </summary>
        MatrixController controller;

        /// <summary>
        /// Конструктор операций над матрицами
        /// </summary>
        public MatrixOperations()
        {
            Row_1 = 1;
            Column_1 = 1;
            Row_2 = 1;
            Column_2 = 1;
        }

        /// <summary>
        /// Операции над матрицами
        /// 0 - Умножение матрицы на число
        /// 1 - Сложение матриц
        /// 2 - Вычитание матриц
        /// 3 - Умножение матриц
        /// 4 - Вычисление детерминанта матрицы
        /// </summary>
        /// <param name="code"> Код операци </param>
        public void show(byte code)
        {
            switch (code)
            {
                case 0:
                    Operation_1();
                    break;
                case 1:
                    Operation_2();
                    break;
                case 2:
                    Operation_3();
                    break;
                case 3:
                    Operation_4();
                    break;
                case 4:
                    Operation_5();
                    break;
            }
        }

        /// <summary>
        /// Операция умножения матрицы на число
        /// </summary>
        void Operation_1()
        {
            Console.Clear();

            Console.Write($"Введите количество строк матрицы ({minRow} - {maxRow}): ");
            string strRow = Console.ReadLine();

            Console.Write($"Введите количество столбцов матрицы ({minColumn} - {maxColumn}): ");
            string strColumn = Console.ReadLine();

            Console.Write("Введите число: ");
            string strNumber = Console.ReadLine();

            double Number;

            if (double.TryParse(strNumber, out Number))
            {
                if(dataEntryVerification(strRow, strColumn, out Row_1, out Column_1))
                {
                    if(dataRangeCheck(minRow, maxRow, Row_1) && dataRangeCheck(minColumn, maxColumn, Column_1))
                    {
                        A = new Matrix(Row_1, Column_1);
                        controller = new MatrixController();

                        A.createMatrix(-100, 100);
                        Console.WriteLine("Исходная матрица: ");
                        A.printMatrix();
                        Console.WriteLine($"Результат умножения матрицы на число {Number}: ");
                        controller.MatrixMultByNumber(A, Number).printMatrix();                        
                    }
                    else
                    {
                        Console.WriteLine("Диапазон значений не соответствует!");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода данных!");
                }
            }
            else 
            {
                Console.WriteLine("Ошибка ввода данных!");
            }
        }

        /// <summary>
        /// Сложение двух матриц
        /// </summary>
        void Operation_2()
        {
            Console.Clear();

            Console.Write($"Введите количество строк 1-й матрицы ({minRow} - {maxRow}): ");
            string strRow_1 = Console.ReadLine();

            Console.Write($"Введите количество столбцов 1-й матрицы ({minColumn} - {maxColumn}): ");
            string strColumn_1 = Console.ReadLine();

            Console.Write($"Введите количество строк 2-й матрицы ({minRow} - {maxRow}): ");
            string strRow_2 = Console.ReadLine();

            Console.Write($"Введите количество столбцов 2-й матрицы ({minColumn} - {maxColumn}): ");
            string strColumn_2 = Console.ReadLine();

            if (dataEntryVerification(strRow_1, strColumn_1, out Row_1, out Column_1) && 
                dataEntryVerification(strRow_2, strColumn_2, out Row_2, out Column_2))
            {
                if (dataRangeCheck(minRow, maxRow, Row_1) && 
                    dataRangeCheck(minColumn, maxColumn, Column_1) && 
                    dataRangeCheck(minRow, maxRow, Row_2) && 
                    dataRangeCheck(minRow, maxRow, Column_2))
                {
                    A = new Matrix(Row_1, Column_1);
                    B = new Matrix(Row_2, Column_2);
                    controller = new MatrixController();

                    if(controller.Compare(A, B))
                    {
                        Console.WriteLine("Исходные матрицы: ");
                        A.createMatrix(-100, 100);
                        A.printMatrix();
                        B.createMatrix(-100, 100);
                        B.printMatrix();

                        Console.WriteLine("Результат сложения матриц: ");

                        controller.Add(A, B).printMatrix();
                    }
                    else
                    {
                        Console.WriteLine("Данные матрицы сложить невозможно!");
                    }
                }
                else
                {
                    Console.WriteLine("Диапазон значений не соответствует!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных!");
            }
        }

        /// <summary>
        /// Вычитание двух матриц
        /// </summary>
        void Operation_3()
        {
            Console.Clear();

            Console.Write($"Введите количество строк 1-й матрицы ({minRow} - {maxRow}): ");
            string strRow_1 = Console.ReadLine();

            Console.Write($"Введите количество столбцов 1-й матрицы ({minColumn} - {maxColumn}): ");
            string strColumn_1 = Console.ReadLine();

            Console.Write($"Введите количество строк 2-й матрицы ({minRow} - {maxRow}): ");
            string strRow_2 = Console.ReadLine();

            Console.Write($"Введите количество столбцов 2-й матрицы ({minColumn} - {maxColumn}): ");
            string strColumn_2 = Console.ReadLine();

            if (dataEntryVerification(strRow_1, strColumn_1, out Row_1, out Column_1) &&
                dataEntryVerification(strRow_2, strColumn_2, out Row_2, out Column_2))
            {
                if (dataRangeCheck(minRow, maxRow, Row_1) &&
                    dataRangeCheck(minColumn, maxColumn, Column_1) &&
                    dataRangeCheck(minRow, maxRow, Row_2) &&
                    dataRangeCheck(minRow, maxRow, Column_2))
                {
                    A = new Matrix(Row_1, Column_1);
                    B = new Matrix(Row_2, Column_2);
                    controller = new MatrixController();

                    if (controller.Compare(A, B))
                    {
                        Console.WriteLine("Исходные матрицы: ");
                        A.createMatrix(-100, 100);
                        A.printMatrix();
                        B.createMatrix(-100, 100);
                        B.printMatrix();

                        Console.WriteLine("Результат вычитания матриц: ");

                        controller.Sub(A, B).printMatrix();
                    }
                    else
                    {
                        Console.WriteLine("Данные матрицы вычесть невозможно!");
                    }
                }
                else
                {
                    Console.WriteLine("Диапазон значений не соответствует!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных!");
            }
        }

        /// <summary>
        /// Умножение двух матриц
        /// </summary>
        void Operation_4()
        {
            Console.Clear();

            Console.Write($"Введите количество строк 1-й матрицы ({minRow} - {maxRow}): ");
            string strRow_1 = Console.ReadLine();

            Console.Write($"Введите количество столбцов 1-й матрицы ({minColumn} - {maxColumn}): ");
            string strColumn_1 = Console.ReadLine();

            Console.Write($"Введите количество строк 2-й матрицы ({minRow} - {maxRow}): ");
            string strRow_2 = Console.ReadLine();

            Console.Write($"Введите количество столбцов 2-й матрицы ({minColumn} - {maxColumn}): ");
            string strColumn_2 = Console.ReadLine();

            if (dataEntryVerification(strRow_1, strColumn_1, out Row_1, out Column_1) &&
                dataEntryVerification(strRow_2, strColumn_2, out Row_2, out Column_2))
            {
                if (dataRangeCheck(minRow, maxRow, Row_1) &&
                    dataRangeCheck(minColumn, maxColumn, Column_1) &&
                    dataRangeCheck(minRow, maxRow, Row_2) &&
                    dataRangeCheck(minRow, maxRow, Column_2))
                {
                    A = new Matrix(Row_1, Column_1);
                    B = new Matrix(Row_2, Column_2);
                    controller = new MatrixController();

                    if (controller.MultiplicationResolution(A, B))
                    {
                        Console.WriteLine("Исходные матрицы: ");
                        A.createMatrix(-100, 100);
                        A.printMatrix();
                        B.createMatrix(-100, 100);
                        B.printMatrix();

                        Console.WriteLine("Результат умножения матриц: ");

                        //Умножение матриц стандартным методом
                        controller.Mult(A, B).printMatrix();

                        //Умножение матриц методом Винограда - Штрассена
                        //StrassenAlgorithm.Multiplication(A, B).printMatrix();
                    }
                    else
                    {
                        Console.WriteLine("Данные матрицы умножить невозможно!");
                    }
                }
                else
                {
                    Console.WriteLine("Диапазон значений не соответствует!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных!");
            }
        }

        /// <summary>
        /// Вычисление детерминанта матрицы
        /// </summary>
        void Operation_5()
        {
            Console.Clear();

            Console.Write($"Введите количество строк матрицы ({minRow} - {maxRow}): ");
            string strRow = Console.ReadLine();

            Console.Write($"Введите количество столбцов матрицы ({minColumn} - {maxColumn}): ");
            string strColumn = Console.ReadLine();

            if (dataEntryVerification(strRow, strColumn, out Row_1, out Column_1))
            {
                if (dataRangeCheck(minRow, maxRow, Row_1) && dataRangeCheck(minColumn, maxColumn, Column_1))
                {
                    if(Row_1 == Column_1)
                    {
                        A = new Matrix(Row_1, Column_1);

                        A.createMatrix(-100, 100);
                        Console.WriteLine("Исходная матрица: ");
                        A.printMatrix();
                        Console.WriteLine($"Детерминант матрицы равен: {A.Determinant()} ");
                    }
                    else
                    {
                        Console.WriteLine("Матрица не является квадратной!");
                    }                                       
                }
                else
                {
                    Console.WriteLine("Диапазон значений не соответствует!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных!");
            }
        }

        /// <summary>
        /// Конвертация строковых параметров в числа с проверкой корректности
        /// </summary>
        bool dataEntryVerification(string strRow, string strColumn, out int row, out int column)
        {
            row = 0;
            column = 0;

            if (int.TryParse(strRow, out row))
            {
                if(int.TryParse(strColumn, out column))
                {
                    return true;
                }

                return false;
            }

            return false;
        }
        
        /// <summary>
        /// Проверка принадлежности числа заданному диапазону
        /// </summary>
        bool dataRangeCheck(int min, int max, int value)
        {
            if(min <= value && value <= max)
            {
                return true;
            }

            return false;
        }
    }
}
