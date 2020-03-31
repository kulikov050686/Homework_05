using System;
using System.Runtime.InteropServices;
using Homework_05.Model;

namespace Homework_05.Controller
{
    public static class StrassenAlgorithm
    {
        [DllImport("MyLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void VinohradStrassenAlgorithm([In, Out] double[] c, [In, Out] double[] a, [In, Out] double[] b, int N);

        static double[] Vector_1;
        static double[] Vector_2;
        static int Size;
        static int ColumnsMatrixOut;
        static int RowsMatrixOut;

        /// <summary>
        /// Умножение матриц методом Винограда - Штрассена
        /// </summary>        
        public static Matrix Multiplication(Matrix A, Matrix B)
        {
            bool EndOfCheck = false;            

            if (A.Column == B.Row)
            {
                RowsMatrixOut = A.Row;
                ColumnsMatrixOut = B.Column;

                do
                {
                    if (SquareAndMultiplicityOfTwo(A) && SquareAndMultiplicityOfTwo(B))
                    {
                        if (MatrixComparison(A, B))
                        {                            
                            Vector_1 = new double[A.SizeMatrix];
                            Vector_1 = Linalization(A);
                            Vector_2 = new double[B.SizeMatrix];
                            Vector_2 = Linalization(B);

                            Size = A.Column;

                            EndOfCheck = true;
                        }
                        else
                        {
                            int ColumnsA = A.Column;
                            int RowsA = A.Row;
                            int ColumnsB = B.Column;
                            int RowsB = B.Row;

                            if (A.SizeMatrix > B.SizeMatrix)
                            {
                                B.AddColumns(ColumnsA - ColumnsB);
                                B.AddRows(RowsA - RowsB);
                            }

                            if (B.SizeMatrix > A.SizeMatrix)
                            {
                                A.AddColumns(ColumnsB - ColumnsA);
                                A.AddRows(RowsB - RowsA);
                            }
                        }
                    }
                    else
                    {
                        if (!SquareAndMultiplicityOfTwo(A))
                        {
                            A = MatrixSquareMultipleOfTwo(A);
                        }

                        if (!SquareAndMultiplicityOfTwo(B))
                        {
                            B = MatrixSquareMultipleOfTwo(B);
                        }
                    }
                }
                while (!EndOfCheck);

                return Strassen();
            }

            throw new Exception("Невозможно перемножить матрицы!");
        }

        /// <summary>
        /// Проверяет является ли число степенью двойки
        /// </summary>
        /// <param name="number"> Вводимое число </param>
        private static bool DegreeOfTwo(int number)
        {
            if (number > 0)
            {
                if ((number & (number - 1)) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Сравнение матриц
        /// </summary>        
        private static bool MatrixComparison(Matrix matrix_1, Matrix matrix_2)
        {
            if (matrix_1.Column == matrix_2.Column && matrix_1.Row == matrix_2.Row)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверка на квадратность матрицы и кратность её размера двум
        /// </summary>       
        private static bool SquareAndMultiplicityOfTwo(Matrix matrix)
        {
            if (matrix.IsSquare && DegreeOfTwo(matrix.SizeMatrix))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Приведение матрицы к квадратной форме
        /// </summary>
        private static Matrix MatrixToSquare(Matrix matrix)
        {
            int Rows = matrix.Row;
            int Columns = matrix.Column;

            if (Columns > Rows)
            {
                matrix.AddRows(Columns - Rows);
            }

            if (Columns < Rows)
            {
                matrix.AddColumns(Rows - Columns);
            }

            return matrix;
        }

        /// <summary>
        /// Приведение матрицы к квадратному виду кратному двум
        /// </summary>
        private static Matrix MatrixSquareMultipleOfTwo(Matrix matrix)
        {
            if (matrix.IsSquare)
            {
                matrix.AddColumns(1);
                matrix.AddRows(1);

                return matrix;
            }
            else
            {
                matrix = MatrixToSquare(matrix);

                if (DegreeOfTwo(matrix.SizeMatrix))
                {
                    return matrix;
                }
                else
                {
                    matrix.AddColumns(1);
                    matrix.AddRows(1);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Линализация матрицы
        /// </summary>        
        private static double[] Linalization(Matrix matrix)
        {
            double[] Vector = new double[matrix.SizeMatrix];
            int Rows = matrix.Row;
            int Columns = matrix.Column;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Vector[i * Columns + j] = matrix.getItem(i, j);
                }
            }

            return Vector;
        }

        /// <summary>
        /// Алгоритм Винограда - Штрассена
        /// </summary>
        private static Matrix Strassen()
        {
            double[] ArrayOut = new double[Size * Size];
            Matrix matrix = new Matrix(Size, Size);
            
            VinohradStrassenAlgorithm(ArrayOut, Vector_1, Vector_2, Size);
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix.setItem(i, j, ArrayOut[i * Size + j]);
                }
            }

            if(matrix.Column == ColumnsMatrixOut && matrix.Row == RowsMatrixOut)
            {
                return matrix;
            }

            bool EndColumn = false;
            bool EndRow = false;

            while (!(EndColumn && EndRow))
            {
                int N = matrix.Column;
                int M = matrix.Row;

                if (N == ColumnsMatrixOut)
                {
                    EndColumn = true;
                }
                else
                {
                    matrix.deleteColumn(N - 1);
                }

                if (M == RowsMatrixOut)
                {
                    EndRow = true;
                }
                else
                {
                    matrix.deleteRow(M - 1);
                }
            }

            return matrix;
        }
    }
}
