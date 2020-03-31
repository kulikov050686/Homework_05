using System;

namespace Homework_05.Model
{
    public class Matrix
    {
        /// <summary>
        /// Двумерная матрица
        /// </summary>
        double[,] Vector;

        /// <summary>
        /// Число столбцов матрицы
        /// </summary>
        public int Column { get; private set; }
        
        /// <summary>
        /// Число строк матрицы
        /// </summary>
        public int Row { get; private set; }        

        /// <summary>
        /// Является ли матрица квадратной
        /// </summary>
        public bool IsSquare { get => Column == Row; }

        /// <summary>
        /// Размер матрицы
        /// </summary>
        public int SizeMatrix { get => Column * Row; }               

        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random Rand;

        /// <summary>
        /// Конструктор новой матрицы
        /// </summary>
        /// <param name="NumberOfRow"> Количество строк </param>
        /// <param name="NumberOfColumns"> Количество столбцов </param>
        public Matrix(int NumberOfRow, int NumberOfColumns)
        {
            if(NumberOfColumns >= 1 && NumberOfRow >= 1)
            {
                Column = NumberOfColumns;
                Row = NumberOfRow;                

                Vector = new double[Row, Column];               
            }
            else
            {
                throw new ArgumentException("Матрицы такой размерности не существует!");
            }
        }

        /// <summary>
        /// Установить данные по номеру элемента матрицы
        /// </summary>
        /// <param name="rowNumber"> Номер строки </param>
        /// <param name="columnNumber"> Номер столбца </param>
        /// <param name="data"> Данные </param>
        public void setItem(int rowNumber, int columnNumber, double data)
        {
            if (0 <= rowNumber && rowNumber < Row &&  0 <= columnNumber && columnNumber < Column)
            {
                Vector[rowNumber, columnNumber] = data;
            }
            else
            {
                throw new ArgumentException("Элемента с таким номером не существует!");
            }
        }

        /// <summary>
        /// Получить данные по номеру элемента матрицы
        /// </summary>
        /// <param name="rowNumber"> Номер строки </param>
        /// <param name="columnNumber"> Номер столбца </param>
        /// <returns></returns>
        public double getItem(int rowNumber, int columnNumber)
        {
            if (0 <= rowNumber && rowNumber < Row && 0 <= columnNumber && columnNumber < Column)
            {
               return Vector[rowNumber, columnNumber];
            }            

            throw new ArgumentException("Элемента с таким номером не существует!");            
        }

        /// <summary>
        /// Создаёт матрицу и заполняет её числами из диапазона [min, max]
        /// </summary>
        /// <param name="min"> Минимальное число диапазона </param>
        /// <param name="max"> Максимальное число диапазона </param>
        public void createMatrix(int min, int max)
        {
            Rand = new Random();

            for(int i = 0; i < Row; i++)
            {
                for(int j = 0; j < Column; j++)
                {
                    Vector[i, j] = Rand.Next(min, max + 1);
                }
            }
        }

        /// <summary>
        /// Печать матрицы
        /// </summary>
        public void printMatrix()
        {
            for (int i = 0; i < Row; i++)
            {
                Console.Write("|");

                for (int j = 0; j < Column; j++)
                {
                    Console.Write($"{Vector[i, j], 8:0.0}");                    
                }

                Console.Write($"{"|", 4}");
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        
        /// <summary>
        /// Удаление столбца матрицы по номеру
        /// </summary>
        /// <param name="column"> Номер столбца </param>
        public bool deleteColumn(int column)
        {
            if(Column > 1)
            {
                if (0 <= column && column < Column)
                {
                    double[,] Temp = new double[Row, Column - 1];

                    for (int i = 0; i < Row; i++)
                    {
                        for (int j = 0, p = 0; j < Column - 1; j++, p++)
                        {
                            if (p == column)
                            {
                                p++;
                            }

                            Temp[i, j] = Vector[i, p];
                        }
                    }

                    Column--;
                    Vector = new double[Row, Column];

                    for (int i = 0; i < Row; i++)
                    {
                        for (int j = 0; j < Column; j++)
                        {
                            Vector[i, j] = Temp[i, j];
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Удаление строки матрицы по номеру
        /// </summary>
        /// <param name="row"> Номер строки </param>
        public bool deleteRow(int row)
        {
            if(Row > 1)
            {
                if (0 <= row && row < Row)
                {
                    double[,] Temp = new double[Row - 1, Column];

                    for (int i = 0, p = 0; i < Row - 1; i++, p++)
                    {
                        for (int j = 0; j < Column; j++)
                        {
                            if (p == row)
                            {
                                p++;
                            }

                            Temp[i, j] = Vector[p, j];
                        }
                    }

                    Row--;
                    Vector = new double[Row, Column];

                    for (int i = 0; i < Row; i++)
                    {
                        for (int j = 0; j < Column; j++)
                        {
                            Vector[i, j] = Temp[i, j];
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Добавить колонки
        /// </summary>
        /// <param name="NumberOfColumns"> Число добавляемых колонок </param>
        public bool AddColumns(int NumberOfColumns)
        {
            if(NumberOfColumns > 0)
            {
                double[,] Temp = new double[Row, Column];

                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0, p = 0; j < Column; j++, p++)
                    {
                        Temp[i, j] = Vector[i, j];
                    }
                }

                int tempColumn = Column;
                Column += NumberOfColumns;
                Vector = new double[Row, Column];

                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Column; j++)
                    {
                        if(j < tempColumn)
                        {
                            Vector[i, j] = Temp[i, j];
                        }
                        else
                        {
                            Vector[i, j] = 0;
                        }                        
                    }
                }

                return true;
            }

            return false;            
        }

        /// <summary>
        /// Добавить строки
        /// </summary>
        /// <param name="NumberOfRows"> Число добавляемых строк </param>
        /// <returns></returns>
        public bool AddRows(int NumberOfRows)
        {
            if(NumberOfRows > 0)
            {
                double[,] Temp = new double[Row, Column];

                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0, p = 0; j < Column; j++, p++)
                    {
                        Temp[i, j] = Vector[i, j];
                    }
                }

                int tempRow = Row;
                Row += NumberOfRows;
                Vector = new double[Row, Column];

                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Column; j++)
                    {
                        if (i < tempRow)
                        {
                            Vector[i, j] = Temp[i, j];
                        }
                        else
                        {
                            Vector[i, j] = 0;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Создать матрицу без столбца
        /// </summary>
        /// <param name="column"> Номер удоляемого столбца </param>
        public Matrix createMatrixWithoutColumn(int column)
        {
            if (Column > 1)
            {
                if (0 <= column && column < Column)
                {
                    double[,] Temp = new double[Row, Column - 1];

                    for (int i = 0; i < Row; i++)
                    {
                        for (int j = 0, p = 0; j < Column - 1; j++, p++)
                        {
                            if (p == column)
                            {
                                p++;
                            }

                            Temp[i, j] = Vector[i, p];
                        }
                    }

                    Matrix NewMatrix = new Matrix(Row, Column - 1);                      

                    for (int i = 0; i < Row; i++)
                    {
                        for (int j = 0; j < Column - 1; j++)
                        {
                            NewMatrix.setItem(i, j, Temp[i, j]);
                        }
                    }

                    return NewMatrix;
                }
                else
                {
                    throw new ArgumentException("Колонки с таким номером не существует!");
                }
            }

            throw new ArgumentException("Ошибка операции!");
        }

        /// <summary>
        /// Создать матрицу без строки
        /// </summary>
        /// <param name="row"> Номер удоляемой строки </param>        
        public Matrix createMatrixWithoutRow(int row)
        {
            if (Row > 1)
            {
                if (0 <= row && row < Row)
                {
                    double[,] Temp = new double[Row - 1, Column];

                    for (int i = 0, p = 0; i < Row - 1; i++, p++)
                    {
                        for (int j = 0; j < Column; j++)
                        {
                            if (p == row)
                            {
                                p++;
                            }

                            Temp[i, j] = Vector[p, j];
                        }
                    }

                    Matrix NewMatrix = new Matrix(Row - 1, Column);

                    for (int i = 0; i < Row - 1; i++)
                    {
                        for (int j = 0; j < Column; j++)
                        {
                            NewMatrix.setItem(i, j, Temp[i, j]);
                        }
                    }

                    return NewMatrix;
                }
                else
                {
                    throw new ArgumentException("Строки с таким номером не существует!");
                }
            }

            throw new ArgumentException("Ошибка операции!");
        }

        /// <summary>
        /// Детерминант матрицы
        /// </summary>
        public double Determinant()
        {
            if(IsSquare)
            {
                if(SizeMatrix == 4)
                {
                    return Vector[0, 0] * Vector[1, 1] - Vector[0, 1] * Vector[1, 0];
                }

                double result = 0;

                for(int j = 0; j < Column; j++)
                {
                    result += (j % 2 == 1 ? 1 : -1) * Vector[1, j] * createMatrixWithoutColumn(j).createMatrixWithoutRow(1).Determinant();
                }

                return result;
            }

            throw new ArgumentException("Матрица не является квадратной!");
        }
    }
}
